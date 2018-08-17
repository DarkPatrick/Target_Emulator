using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Web;
//using System.Diagnostics.Stopwatch;
//using commonTypes;

namespace TarEmu3
{
    public partial class MainForm : Form
    {
        public struct Param
        {
            public int start_bit;
            public int bit_len;
            public string name;
            public string type;
            public string value;
        }

        public struct SimpleStats
        {
            public UInt64 lost_crc;
            public UInt64 trm_packs;
            public UInt64 rcv_packs;
            //public UInt64 rcv_bytes;
        }

        enum PROTICOLS { NONE, SLIP, CRC8 };
        static Mutex InstanceCheckMutex;
        static bool reading = false;
        static PROTICOLS[] receive_protocols = new PROTICOLS[10];
        static PROTICOLS[] transmit_protocols = new PROTICOLS[10];
        static int receive_protocols_num = 0;
        static int transmit_protocols_num = 0;
        static byte[] rec_buffer = new byte[4096];
        static byte[] trm_buffer = new byte[4096];
        static byte[] decoded_buf = new byte[4096];
        static int rec_buf_size = 0;
        static int trm_buf_size = 0;
        static Param[] receive_params;
        static Param[] transmit_params;
        static int receive_params_num;
        static int transmit_params_num;
        static string save_files_path = AppDomain.CurrentDomain.BaseDirectory;
        static string load_files_path = AppDomain.CurrentDomain.BaseDirectory;
        static string rec_data_file_name = "";
        static string rec_bin_file_name = "";
        static System.IO.StreamWriter h_save_file;
        static System.IO.BinaryWriter h_b_save_file;
        static bool writing_active = false;
        static Stopwatch update_timer = new Stopwatch();
        static string current_ini_content = "";
        static bool want_to_reload_ini = false;
        static Process notepad_proc;
        static string[] recent_files = new string[10];
        static System.Windows.Forms.ToolStripMenuItem[] recent_file_menu_item = new System.Windows.Forms.ToolStripMenuItem[10];
        static SimpleStats simple_stats;

        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadAllSettings()
        {
            SerialPortSetup.app_num = 0;

            for (UInt32 i = 0; ; ++i)
            {
                InstanceCheckMutex = new Mutex(true, "Target Emulator " + i.ToString(), out bool is_new);
                if (is_new)
                {
                    SerialPortSetup.app_num = i;
                    break;
                }
            }

            SerialPortSetup f = new SerialPortSetup();
            f.SerialPortInit();
            main_menu.ShowItemToolTips = true;

            save_files_path = AppDomain.CurrentDomain.BaseDirectory;
            load_files_path = AppDomain.CurrentDomain.BaseDirectory;
            save_setup_bt.ToolTipText = save_files_path;
            load_setup_bt.ToolTipText = load_files_path;
            open_file_dialog.InitialDirectory = load_files_path;

            try
            {
                var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).OpenSubKey("paths");
                save_files_path = key.GetValue("save_path").ToString();
                save_setup_bt.ToolTipText = save_files_path;
                load_files_path = key.GetValue("load_path").ToString();
                load_setup_bt.ToolTipText = load_files_path;
                open_file_dialog.InitialDirectory = load_files_path;
            }
            catch
            {
            }

            for (var i = 0; i < recent_files.Length; ++i)
            {
                recent_files[i] = "";
            }
            try
            {
                var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).OpenSubKey("recent");

                for (var i = 0; i < recent_files.Length; ++i)
                {
                    recent_files[i] = key.GetValue(i.ToString()).ToString();
                    recent_file_menu_item[i] = new System.Windows.Forms.ToolStripMenuItem();
                    if (recent_files[i] != "")
                    {
                        recent_file_menu_item[i].Text = recent_files[i];
                        this.recentToolStripMenuItem.DropDownItems.Add(recent_file_menu_item[i]);
                        recent_file_menu_item[i].Click += new System.EventHandler(this.RecentFileMenuItem_Click);
                    }
                }
            }
            catch
            {
            }

            try
            {
                var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).OpenSubKey("read_write");


                bool.TryParse(key.GetValue("write_txt").ToString(), out bool wr_ch);
                autoTextWriteToolStripMenuItem.Checked = wr_ch;
            }
            catch
            {
            }
        }

        public void SaveAllSettings()
        {
            var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).CreateSubKey("paths");
            key.SetValue("save_path", save_files_path);
            key.SetValue("load_path", load_files_path);

            if (open_file_dialog.FileName != "*.ini")
            {
                for (var i = 0; i < recent_files.Length; ++i)
                {
                    if (recent_files[i] == open_file_dialog.FileName)
                    {
                        recent_files[i] = "";
                        for (var j = i; j < recent_files.Length - 1; ++j)
                        {
                            recent_files[j] = recent_files[j + 1];
                        }
                    }
                }

                for (var i = recent_files.Length - 1; i > 0; --i)
                {
                    recent_files[i] = recent_files[i - 1];
                }
                recent_files[0] = open_file_dialog.FileName;

                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).CreateSubKey("recent");

                for (var i = 0; i < recent_files.Length; ++i)
                {
                    key.SetValue(i.ToString(), recent_files[i]);
                }
            }

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Target Emulator " + SerialPortSetup.app_num.ToString()).CreateSubKey("read_write");
            key.SetValue("write_txt", autoTextWriteToolStripMenuItem.Checked);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectionOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop_bt_Click(sender, e);
            SerialPortSetup serial_port_setup = new SerialPortSetup();
            serial_port_setup.Show();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //this.Text = SerialPortSetup.com_port_name;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.KeepAlive] = "True";
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0) Gecko/20100101 Firefox/61.0";
                client.DownloadFile("https://api.github.com/repos/DarkPatrick/Target_Emulator/releases/latest", "latest_version.json");
                //TODO open and seek for https://github.com/DarkPatrick/Target_Emulator/releases/download/....
            }

            LoadAllSettings();

            update_timer.Start();
        }

        private void Run_bt_Click(object sender, EventArgs e)
        {
            serial_port.PortName = SerialPortSetup.com_port_name_val;
            serial_port.BaudRate = SerialPortSetup.baud_rate_val;
            serial_port.DataBits = SerialPortSetup.data_bits_val;
            serial_port.StopBits = SerialPortSetup.stop_bits_val;
            serial_port.Parity = SerialPortSetup.parity_val;
            try
            {
                serial_port.Open();
                serial_port.ReadExisting();
                run_bt.Enabled = false;
                stop_bt.Enabled = true;
                step_bt.Enabled = true;
                reading = true;
                port_check_timer.Enabled = true;
                connectionOptionsToolStripMenuItem.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ошибка открытия порта", "COM error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Open_file_bt_Click(object sender, EventArgs e)
        {
            if (open_file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(open_file_dialog.FileName);
                current_ini_content = sr.ReadToEnd();
                GetIniFile(current_ini_content);
                sr.Close();
            }
        }

        private void Stop_bt_Click(object sender, EventArgs e)
        {
            port_check_timer.Enabled = false;
            if (serial_port.IsOpen)
            {
                serial_port.Close();
                connectionOptionsToolStripMenuItem.Enabled = true;
            }
            run_bt.Enabled = true;
            stop_bt.Enabled = false;
            step_bt.Enabled = false;
            reading = false;
        }

        private void Step_bt_Click(object sender, EventArgs e)
        {
            reading = !reading;
            // TODO: сделать, чтобы по нажатию читался один кадр, а по кнопке "пуск" всё запускалось внормальном состоянии
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_file_bt_Click(sender, e);
        }

        private void GetIniFile(string file_content)
        {
            bintxtToolStripMenuItem.Enabled = true;
            if (serial_port.IsOpen)
            {
                Stop_bt_Click(this, null);
            }
            rec_data_grid.Rows.Clear();
            rec_data_grid.Refresh();
            trm_data_grid.Rows.Clear();
            trm_data_grid.Refresh();

            file_content = file_content.Replace(Convert.ToChar(9), ' ');
            var find_param_name = false;
            var find_var = 0;
            var param_name = "";
            //var par_val = "";
            string[] par_val = new string[2048];
            var square_br = 0;
            var curly_br = 0;

            for (var i = 0; i < file_content.Length; ++i)
            {
                if (file_content[i] == '[')
                {
                    square_br++;
                }
                else if (file_content[i] == ']')
                {
                    square_br--;
                    //find_var = true;
                }
                else if (file_content[i] == '{')
                {
                    curly_br++;
                }
                else if (file_content[i] == '}')
                {
                    curly_br--;
                    //find_var = true;
                }
                else if (file_content[i] == '=')
                {
                    find_param_name = true;
                }
                else if ((file_content[i] == ',') && (square_br == 1))
                {
                    //find_var = true;
                    find_var++;
                    par_val[find_var] = "";
                }
                else if (!find_param_name)
                {
                    param_name += file_content[i];
                }
                //else if ((find_param_name) && (!find_var))
                else if (find_param_name)
                {
                    //par_val += file_content[i];
                    par_val[find_var] += file_content[i];
                }

                if ((square_br == 0) && (file_content[i] == ']'))
                {
                    param_name = param_name.Replace("\n", "").Replace("\r", "");
                    param_name = param_name.Trim().ToLower();
                    for (var j = 0; j <= find_var; ++j)
                    {
                        par_val[j] = par_val[j].Replace("\n", "").Replace("\r", "").Trim();
                    }

                    if (param_name == "receive_protocols")
                    {
                        for (var j = 0; j <= find_var; ++j)
                        {
                            if (par_val[j].ToLower() == "slip")
                            {
                                receive_protocols[receive_protocols_num] = PROTICOLS.SLIP;
                                receive_protocols_num++;
                            }
                            else if (par_val[j].ToLower() == "crc8")
                            {
                                receive_protocols[receive_protocols_num] = PROTICOLS.CRC8;
                                receive_protocols_num++;
                            }
                        }
                    }
                    else if (param_name == "transmit_protocols")
                    {
                        for (var j = 0; j <= find_var; ++j)
                        {
                            if (par_val[j].ToLower() == "slip")
                            {
                                transmit_protocols[transmit_protocols_num] = PROTICOLS.SLIP;
                                transmit_protocols_num++;
                            }
                            else if (par_val[j].ToLower() == "crc8")
                            {
                                transmit_protocols[transmit_protocols_num] = PROTICOLS.CRC8;
                                transmit_protocols_num++;
                            }
                        }
                    }
                    else if (param_name == "receive_params")
                    {
                        receive_params_num = (find_var + 1) / 4;
                        receive_params = new Param[receive_params_num];
                        rec_data_grid.RowHeadersVisible = false;
                        rec_data_grid.ColumnCount = 3;
                        rec_data_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        rec_data_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        rec_data_grid.Columns[0].Name = "#";
                        //rec_data_grid.Columns[0].ValueType = GetType();
                        rec_data_grid.Columns[1].Name = "Имя параметра";
                        rec_data_grid.Columns[2].Name = "Значение параметра";

                        rec_data_grid.Height = 50;
                        for (var j = 0; j < receive_params_num; ++j)
                        //for (var j = 0; j < 20; ++j)
                        {
                            int.TryParse(par_val[j * 4], out receive_params[j].start_bit);
                            int.TryParse(par_val[j * 4 + 1], out receive_params[j].bit_len);
                            receive_params[j].name = par_val[j * 4 + 2];
                            receive_params[j].type = par_val[j * 4 + 3];
                            string[] row1 = { "", receive_params[j].name, "" };
                            //string[] row1 = { "rabbit", "aas" };
                            rec_data_grid.Rows.Add(row1);
                            rec_data_grid.Rows[j].Cells[0].Value = j;
                            rec_data_grid.Height += rec_data_grid.Rows[rec_data_grid.Rows.Count - 1].Height;
                        }
                        //rec_data_grid.Rows[1].Cells[1].Value = "hello";
                        rec_data_grid.Width = rec_data_grid.Columns[0].Width + rec_data_grid.Columns[1].Width + rec_data_grid.Columns[2].Width + 20;
                        trm_data_grid.Location = new Point(rec_data_grid.Location.X + rec_data_grid.Width, trm_data_grid.Location.Y);
                    }
                    else if (param_name == "transmit_params")
                    {
                        transmit_params_num = (find_var + 1) / 5;
                        transmit_params = new Param[transmit_params_num];
                        trm_data_grid.RowHeadersVisible = false;
                        trm_data_grid.ColumnCount = 3;
                        trm_data_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        trm_data_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        trm_data_grid.Columns[0].Name = "#";
                        trm_data_grid.Columns[1].Name = "Имя параметра";
                        trm_data_grid.Columns[2].Name = "Значение параметра";

                        trm_data_grid.Height = 50;
                        for (var j = 0; j < transmit_params_num; ++j)
                        //for (var j = 0; j < 20; ++j)
                        {
                            int.TryParse(par_val[j * 5], out transmit_params[j].start_bit);
                            int.TryParse(par_val[j * 5 + 1], out transmit_params[j].bit_len);
                            transmit_params[j].name = par_val[j * 5 + 2];
                            transmit_params[j].type = par_val[j * 5 + 3];
                            transmit_params[j].value = par_val[j * 5 + 4];
                            string[] row1 = { "", transmit_params[j].name, transmit_params[j].value };
                            //string[] row1 = { "rabbit", "aas" };
                            trm_data_grid.Rows.Add(row1);
                            trm_data_grid.Rows[j].Cells[0].Value = j;
                            trm_data_grid.Height += trm_data_grid.Rows[trm_data_grid.Rows.Count - 1].Height;
                        }
                        //rec_data_grid.Rows[1].Cells[1].Value = "hello";
                        trm_data_grid.Width = trm_data_grid.Columns[0].Width + trm_data_grid.Columns[1].Width + trm_data_grid.Columns[2].Width + 20;
                    }
                    param_name = "";
                    find_param_name = false;
                    find_var = 0;
                    par_val[0] = "";
                }
            }
        }

        private void ParseReceivedData(byte[] temp_rec_data, bool convert = false, string cv_file_name = null)
        {
            var end_of_pack = false;
            var decoded_pr_len = 0;

            if ((current_ini_content == "") && (!convert))
            {
                return;
            }

            System.IO.StreamWriter sf2 = null;
            if (convert)
            {
                sf2 = new System.IO.StreamWriter(cv_file_name);
                for (var i = 0; i < receive_params_num; ++i)
                {
                    if (i > 0)
                    {
                        sf2.Write(',');
                    }
                    sf2.Write(receive_params[i].name);
                }
                sf2.WriteLine();
            }

            //serial_port.Read(rec_buffer, rec_buf_size, bytes_num);
            //var rec_str = serial_port.ReadExisting();
            //rec_buf_size += bytes_num;
            //while (serial_port.IsOpen && serial_port.BytesToRead > 0)
            for (var buf_pos = 0; buf_pos < temp_rec_data.Length; ++buf_pos)
            {
                if (writing_active)
                {
                    h_b_save_file.Write(temp_rec_data[buf_pos]);
                }
                //rec_buffer[rec_buf_size++] = (byte)serial_port.ReadByte();
                rec_buffer[rec_buf_size++] = temp_rec_data[buf_pos];

                for (var i = 0; i < receive_protocols_num; ++i)
                {
                    // TODO: как вытаскивать сразу несколько SLIPов из одного пакета?
                    if (receive_protocols[i] == PROTICOLS.SLIP)
                    {
                        /*
                        for (var j = 0; j < bytes_num; ++j)
                        {
                            if (rec_buffer[rec_buf_size - bytes_num + j] == (byte)TransferProtocols.SLIP_BYTES.END)
                            {
                                rec_buf_size = rec_buf_size - bytes_num + j + 1;
                                end_of_pack = true;
                                break;
                            }
                        }
                        */
                        if (rec_buf_size == 0)
                        {
                            continue;
                        }
                        if (rec_buffer[rec_buf_size - 1] == (byte)TransferProtocols.SLIP_BYTES.END)
                        {
                            end_of_pack = true;
                            decoded_pr_len = TransferProtocols.Slip(ref rec_buffer, ref decoded_buf, rec_buf_size, TransferProtocols.CODE_TYPE.DDECODE);
                            for (var j = 0; j < decoded_pr_len; ++j)
                            {
                                rec_buffer[j] = decoded_buf[j];
                            }
                            if (decoded_pr_len == 0)
                            {
                                end_of_pack = false;
                                //rec_buf_size = 0;
                            }
                            rec_buf_size = 0;
                        }
                    }
                    else if ((receive_protocols[i] == PROTICOLS.CRC8) && (end_of_pack))
                    {
                        var res = TransferProtocols.CRC8(ref rec_buffer, decoded_pr_len, TransferProtocols.CODE_TYPE.DDECODE);
                        if (res == 0)
                        {
                            end_of_pack = false;
                            simple_stats.lost_crc++;
                        }
                        // TODO: счётчик битых посылок
                    }
                }

                if (end_of_pack)
                {
                    //rec_buf_size = 0;
                    var can_display = false;
                    if (update_timer.ElapsedMilliseconds >= 100)
                    {
                        can_display = true;
                        update_timer.Restart();
                    }

                    for (var i = 0; i < receive_params_num; ++i)
                    {
                        var length = (int)Math.Ceiling((double)(receive_params[i].bit_len) / 8.0);
                        byte[] var_bytes = new byte[8];

                        for (var j = 0; j < var_bytes.Length; ++j)
                        {
                            var_bytes[j] = 0;
                        }
                        for (var j = 0; j < length; ++j)
                        {
                            var_bytes[j] = rec_buffer[receive_params[i].start_bit / 8 + j];
                        }
                        var start_bit_mask = receive_params[i].start_bit - (int)(receive_params[i].start_bit / 8) * 8;
                        byte mask = 0;

                        for (var k = start_bit_mask; k < 8; ++k)
                        {
                            mask += (byte)(1 << k);
                        }

                        var_bytes[0] &= mask;
                        if (receive_params[i].bit_len < 8)
                        {
                            var_bytes[0] >>= (start_bit_mask - receive_params[i].bit_len + 1);
                        }
                        else
                        {
                            var_bytes[0] >>= start_bit_mask;

                            var end_bit_mask = receive_params[i].start_bit + receive_params[i].bit_len - (int)((receive_params[i].start_bit + receive_params[i].bit_len) / 8) * 8;

                            mask = 0;
                            for (var k = end_bit_mask; k < 8; ++k)
                            {
                                mask += (byte)(1 << k);
                            }

                            var_bytes[length - 1] &= mask;
                        }

                        //TODO: правильно обработать битовые поля
                        var str_res = DataProtocols.Display(var_bytes, receive_params[i].type);

                        if (can_display)
                        {
                            rec_data_grid.Rows[i].Cells[2].Value = str_res;
                        }

                        if ((writing_active) && (!convert))
                        {
                            if (autoTextWriteToolStripMenuItem.Checked)
                            {
                                if (i > 0)
                                {
                                    h_save_file.Write(',');
                                }
                                h_save_file.Write(str_res);
                            }
                        }
                        if (convert)
                        {
                            if (i > 0)
                            {
                                sf2.Write(',');
                            }
                            sf2.Write(str_res);
                        }
                    }
                    if ((writing_active) && (autoTextWriteToolStripMenuItem.Checked) && (!convert))
                    {
                        h_save_file.WriteLine();
                    }
                    if (convert)
                    {
                        sf2.WriteLine();
                    }

                    simple_stats.rcv_packs++;
                }

                end_of_pack = false;
            }
        }

        private void Serial_port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //var bytes_num = serial_port.BytesToRead;
            var bytes_num = serial_port.BytesToRead;

            byte[] temp_rec_data = new byte[bytes_num];
            try
            {
                serial_port.Read(temp_rec_data, 0, bytes_num);
            }
            catch
            {
                MessageBox.Show("Ошибка связи", "COM error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ParseReceivedData(temp_rec_data);
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (save_files_path != null)
            {
                dialog.SelectedPath = save_files_path;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                save_files_path = dialog.SelectedPath;
                save_setup_bt.ToolTipText = save_files_path;
            }
        }

        private void Load_setup_bt_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (load_files_path != null)
            {
                dialog.SelectedPath = load_files_path;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                load_files_path = dialog.SelectedPath;
                load_setup_bt.ToolTipText = load_files_path;
                open_file_dialog.InitialDirectory = load_files_path;
            }
        }

        private void SavedFilesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@save_files_path);
            }
            catch
            {
                MessageBox.Show("Ошибка открытия пути", "Path error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(@System.Reflection.Assembly.GetEntryAssembly().Location);
                Process.Start(@AppDomain.CurrentDomain.BaseDirectory);
            }
            catch
            {
                MessageBox.Show("Ошибка открытия пути", "Path error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniFilesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@load_files_path);
            }
            catch
            {
                MessageBox.Show("Ошибка открытия пути", "Path error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceivedDataFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file_dialog.Filter = "Binary files (*.bin)|*.bin";
            save_file_dialog.DefaultExt = "bin";
            save_file_dialog.AddExtension = true;
            if (save_files_path != null)
            {
                save_file_dialog.InitialDirectory = save_files_path;
            }
            if (save_file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rec_bin_file_name = save_file_dialog.FileName;
            }
        }

        private void Wrtie_data_bt_Click(object sender, EventArgs e)
        {
            if (wrtie_data_bt.Checked)
            {
                if (rec_bin_file_name == "")
                {
                    rec_bin_file_name = save_files_path + "\\dataout.bin";
                    rec_data_file_name = save_files_path + "\\dataout.csv";
                }
                else
                {
                    rec_data_file_name = System.IO.Path.GetFileNameWithoutExtension(rec_bin_file_name) + ".csv";
                }

                h_b_save_file = new System.IO.BinaryWriter(System.IO.File.Open(rec_bin_file_name, System.IO.FileMode.OpenOrCreate));

                if (autoTextWriteToolStripMenuItem.Checked)
                {
                    autoTextWriteToolStripMenuItem.Enabled = false;
                    h_save_file = new System.IO.StreamWriter(rec_data_file_name);

                    for (var i = 0; i < receive_params_num; ++i)
                    {
                        if (i > 0)
                        {
                            h_save_file.Write(',');
                        }
                        h_save_file.Write(receive_params[i].name);
                    }
                    h_save_file.WriteLine();
                }

                writing_active = true;
            }
            else
            {
                writing_active = false;
                h_b_save_file.Close();
                if (autoTextWriteToolStripMenuItem.Checked)
                {
                    h_save_file.Close();
                    autoTextWriteToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void Trm_run_bt_Click(object sender, EventArgs e)
        {
            try
            {
                var closed_port = false;

                if (!serial_port.IsOpen)
                {
                    serial_port.Open();
                    closed_port = true;
                }

                for (var i = 0; i < 100; ++i)
                {
                    trm_buffer[i] = 0;
                }
                trm_buf_size = 0;

                for (var i = 0; i < transmit_params_num; ++i)
                {
                    transmit_params[i].value = trm_data_grid.Rows[i].Cells[2].Value.ToString();

                    var length = (int)Math.Ceiling((double)(transmit_params[i].bit_len) / 8.0);
                    byte[] var_bytes = new byte[8];
                    DataProtocols.ConverNumToBytes(transmit_params[i].value, transmit_params[i].type, ref var_bytes);

                    for (var j = 0; j < length; ++j)
                    {
                        trm_buffer[transmit_params[i].start_bit / 8 + j] |= var_bytes[j];

                        if (transmit_params[i].start_bit / 8 + j > trm_buf_size)
                        {
                            trm_buf_size = transmit_params[i].start_bit / 8 + j;
                        }
                    }
                }
                trm_buf_size++;

                byte[] encoded_buffer = null;
                var new_len = 0;

                for (var i = 0; i < transmit_protocols_num; ++i)
                {
                    if (transmit_protocols[i] == PROTICOLS.CRC8)
                    {
                        TransferProtocols.CRC8(ref trm_buffer, trm_buf_size, TransferProtocols.CODE_TYPE.ENCODE);
                        trm_buf_size++;
                    }
                    else if (transmit_protocols[i] == PROTICOLS.SLIP)
                    {
                        encoded_buffer = new byte[trm_buf_size + 1];
                        new_len = TransferProtocols.Slip(ref trm_buffer, ref encoded_buffer, trm_buf_size, TransferProtocols.CODE_TYPE.ENCODE);

                        Array.Resize<byte>(ref encoded_buffer, new_len);
                    }
                }

                serial_port.Write(encoded_buffer, 0, new_len);

                simple_stats.trm_packs++;

                if (closed_port)
                {
                    serial_port.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия порта", "COM error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((stop_bt.Enabled) && (!serial_port.IsOpen))
            {
                Stop_bt_Click(sender, e);
                MessageBox.Show("Потеряна связь с портом.", "COM error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Trm_data_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //TODO: не забыть добавить условие на случай периодической записи
            if (trm_data_grid.IsCurrentCellDirty)
            {
                trm_data_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllSettings();
        }

        private void CurrentConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open_file_dialog.FileName != "*.ini")
            {
                notepad_proc = Process.Start("notepad.exe", open_file_dialog.FileName);
                want_to_reload_ini = true;
                editing_timer.Enabled = true;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if ((want_to_reload_ini) && (notepad_proc.HasExited))
            {
                want_to_reload_ini = false;

                System.IO.StreamReader sr = new System.IO.StreamReader(open_file_dialog.FileName);
                var temp = sr.ReadToEnd();
                sr.Close();

                if (!temp.Equals(current_ini_content))
                {
                    current_ini_content = temp;
                    GetIniFile(current_ini_content);
                }

                editing_timer.Enabled = false;
            }
        }

        private void EditExistinginiFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RecentFileMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < recent_file_menu_item.Length; ++i)
            {
                if (sender == recent_file_menu_item[i])
                {
                    open_file_dialog.FileName = recent_file_menu_item[i].Text;
                    System.IO.StreamReader sr = new System.IO.StreamReader(open_file_dialog.FileName);
                    current_ini_content = sr.ReadToEnd();
                    sr.Close();
                    GetIniFile(current_ini_content);
                }
            }
        }

        private void Stat_timer_Tick(object sender, EventArgs e)
        {
            reToolStripMenuItem.Text = "Received packets: " + simple_stats.rcv_packs.ToString();
            sentPacketsToolStripMenuItem.Text = "Sent packets: " + simple_stats.trm_packs.ToString();
            cRCErrors0ToolStripMenuItem.Text = "CRC errors: " + simple_stats.lost_crc.ToString();
        }

        private void OldTarEmuiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open_file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(open_file_dialog.FileName);
                var temp_cont = sr.ReadToEnd();
                var lines_num = 1;
                foreach (var i in temp_cont)
                {
                    if (i == '\n')
                    {
                        lines_num++;
                    }
                }
                string[] lines = new string[lines_num];

                lines_num = 0;
                lines[0] = "";
                foreach (var i in temp_cont)
                {
                    lines[lines_num] += i;
                    if (i == '\n')
                    {
                        if ((lines[lines_num].Contains('"')) || ((lines[lines_num].Contains('[')) && (lines[lines_num].Contains(']'))))
                        {
                            lines[lines_num] = lines[lines_num].Trim();
                        } else
                        {
                            lines[lines_num] = lines[lines_num].Replace(Convert.ToChar(9), ' ').Replace(" ", "");
                        }
                        lines_num++;
                        lines[lines_num] = "";
                    }
                }

                var new_file = "receive_protocols=[\r\n";
                for (var i = 0; i < lines_num; ++i)
                {
                    if ((!lines[i].Contains(';')) && (lines[i].ToLower().Contains("dll=slip.dll")))
                    {
                        new_file += "	SLIP,\r\n";
                    }
                }
                for (var i = 0; i < lines_num; ++i)
                {
                    if ((!lines[i].Contains(';')) && (lines[i].ToLower().Contains("usecrc")) && (lines[i].Contains("1")))
                    {
                        new_file += "	CRC8\r\n";
                    }
                }
                new_file += "]\r\n";
                new_file += "transmit_protocols=[\r\n";
                for (var i = 0; i < lines_num; ++i)
                {
                    if ((!lines[i].Contains(';')) && (lines[i].ToLower().Contains("usecrc")) && (lines[i].Contains("1")))
                    {
                        new_file += "	CRC8,\r\n";
                    }
                }
                for (var i = 0; i < lines_num; ++i)
                {
                    if ((!lines[i].Contains(';')) && (lines[i].ToLower().Contains("dll=slip.dll")))
                    {
                        new_file += "	SLIP\r\n";
                    }
                }
                new_file += "]\r\n";
                var str_rcv_par = "";
                var str_trm_par = "";
                var par_type = 0;
                Param rcv_par;
                Param trm_par;

                rcv_par.name = "";
                rcv_par.start_bit = 0;
                rcv_par.bit_len = 0;
                rcv_par.type = "";
                rcv_par.value = "";
                trm_par.name = "";
                trm_par.start_bit = 0;
                trm_par.bit_len = 0;
                trm_par.type = "";
                trm_par.value = "";
                for (var i = 0; i < lines_num; ++i)
                {
                    var next = false;

                    if (lines[i].ToLower().Contains("[settings\\rs-232 input message (measurement)"))
                    {
                        next = true;
                        par_type = 1;
                    } else if (lines[i].ToLower().Contains("[settings\\rs-232 output message (initialization)"))
                    {
                        next = true;
                        par_type = 2;
                    }
                    if (next)
                    {
                        if (rcv_par.name != "")
                        {
                            str_rcv_par += "	{" + rcv_par.start_bit.ToString() + ", " + rcv_par.bit_len.ToString() + ", " + rcv_par.name + ", " + rcv_par.type + "},\r\n";
                            rcv_par.start_bit = 0;
                            rcv_par.bit_len = 0;
                            rcv_par.name = "";
                            rcv_par.type = "";
                        }
                        else if (trm_par.name != "")
                        {
                            str_trm_par += "	{" + trm_par.start_bit.ToString() + ", " + trm_par.bit_len.ToString() + ", " + trm_par.name + ", " + trm_par.type + ", " + "0" + "},\r\n";
                            trm_par.start_bit = 0;
                            trm_par.bit_len = 0;
                            trm_par.name = "";
                            trm_par.type = "";
                        }
                    }

                    if (lines[i][0] == ';')
                    {
                        continue;
                    }
                    if (lines[i].ToLower().Contains("bytenumber="))
                    {
                        var tmp = "";
                        for (var j = 11; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] >= '0') && (lines[i][j] <= '9'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            int.TryParse(tmp, out rcv_par.start_bit);
                            rcv_par.start_bit *= 8;
                        }
                        if (par_type == 2)
                        {
                            int.TryParse(tmp, out trm_par.start_bit);
                            trm_par.start_bit *= 8;
                        }
                    }
                    else if (lines[i].ToLower().Contains("wordnumber="))
                    {
                        var tmp = "";
                        for (var j = 11; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] >= '0') && (lines[i][j] <= '9'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            int.TryParse(tmp, out rcv_par.start_bit);
                            rcv_par.start_bit = (rcv_par.start_bit - 1) * 16;
                        }
                        if (par_type == 2)
                        {
                            int.TryParse(tmp, out trm_par.start_bit);
                            trm_par.start_bit = (trm_par.start_bit - 1) * 16;
                        }
                    }
                    else if (lines[i].ToLower().Contains("startbit="))
                    {
                        var tmp = "";
                        for (var j = 9; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] >= '0') && (lines[i][j] <= '9'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            int.TryParse(tmp, out int start_bit);
                            rcv_par.start_bit += start_bit;
                        }
                        if (par_type == 2)
                        {
                            int.TryParse(tmp, out int start_bit);
                            trm_par.start_bit += start_bit;
                        }
                    }
                    else if (lines[i].ToLower().Contains("bytecount="))
                    {
                        var tmp = "";
                        for (var j = 10; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] >= '0') && (lines[i][j] <= '9'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            if (rcv_par.bit_len == 0)
                            {
                                int.TryParse(tmp, out rcv_par.bit_len);
                                rcv_par.bit_len *= 8;
                            }
                        }
                        if (par_type == 2)
                        {
                            if (trm_par.bit_len == 0)
                            {
                                int.TryParse(tmp, out trm_par.bit_len);
                                trm_par.bit_len *= 8;
                            }
                        }
                    }
                    else if (lines[i].ToLower().Contains("countbits="))
                    {
                        var tmp = "";
                        for (var j = 10; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] >= '0') && (lines[i][j] <= '9'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            int.TryParse(tmp, out rcv_par.bit_len);
                        }
                        if (par_type == 2)
                        {
                            int.TryParse(tmp, out trm_par.bit_len);
                        }
                    }
                    else if (lines[i].ToLower().Contains("name="))
                    {
                        var tmp = "";
                        for (var j = 5; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] != '\r') && (lines[i][j] != '\n') && (lines[i][j] != '"'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if ((tmp.ToLower().Contains("crc")) && (new_file.ToLower().Contains("crc")))
                        {
                            tmp = "";
                        }
                        if (par_type == 1)
                        {
                            rcv_par.name = tmp;
                        }
                        if (par_type == 2)
                        {
                            trm_par.name = tmp;
                        }
                    }
                    else if (lines[i].ToLower().Contains("format="))
                    {
                        var tmp = "";
                        for (var j = 7; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] != '\r') && (lines[i][j] != '\n') && (lines[i][j] != '"'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            if (tmp == "%u")
                            {
                                rcv_par.type = "uint32";
                            }
                            else if (tmp == "%d")
                            {
                                rcv_par.type = "int32";
                            }
                            else if (tmp == "%f")
                            {
                                rcv_par.type = "float";
                            }
                        }
                        if (par_type == 2)
                        {
                            if (tmp == "%u")
                            {
                                trm_par.type = "uint32";
                            }
                            else if (tmp == "%d")
                            {
                                trm_par.type = "int32";
                            }
                            else if (tmp == "%f")
                            {
                                trm_par.type = "float";
                            }
                        }
                    }
                    else if (lines[i].ToLower().Contains("type="))
                    {
                        var tmp = "";
                        for (var j = 5; j < lines[i].Length; ++j)
                        {
                            if ((lines[i][j] != '\r') && (lines[i][j] != '\n') && (lines[i][j] != '"'))
                            {
                                tmp += lines[i][j];
                            }
                        }
                        if (par_type == 1)
                        {
                            if ((tmp == "unsigned") || (tmp == "unsigned long integer"))
                            {
                                rcv_par.type = "uint32";
                            }
                            else if (tmp == "float")
                            {
                                rcv_par.type = "float";
                            }
                            else if (tmp == "double")
                            {
                                rcv_par.type = "double";
                            }
                            else if ((tmp == "byte") || (tmp == "unsigned char"))
                            {
                                rcv_par.type = "byte";
                            }
                        }
                        if (par_type == 2)
                        {
                            if ((tmp == "unsigned") || (tmp == "unsigned long integer"))
                            {
                                trm_par.type = "uint32";
                            }
                            else if (tmp == "float")
                            {
                                trm_par.type = "float";
                            }
                            else if (tmp == "double")
                            {
                                trm_par.type = "double";
                            }
                            else if ((tmp == "byte") || (tmp == "unsigned char"))
                            {
                                trm_par.type = "byte";
                            }
                        }
                    }
                }
                if (rcv_par.name != "")
                {
                    str_rcv_par += "	{" + rcv_par.start_bit.ToString() + ", " + rcv_par.bit_len.ToString() + ", " + rcv_par.name + ", " + rcv_par.type + "},\r\n";
                    rcv_par.start_bit = 0;
                    rcv_par.bit_len = 0;
                    rcv_par.name = "";
                    rcv_par.type = "";
                }
                else if (trm_par.name != "")
                {
                    str_trm_par += "	{" + trm_par.start_bit.ToString() + ", " + trm_par.bit_len.ToString() + ", " + trm_par.name + ", " + trm_par.type + ", " + "0" + "},\r\n";
                    trm_par.start_bit = 0;
                    trm_par.bit_len = 0;
                    trm_par.name = "";
                    trm_par.type = "";
                }
                new_file += "receive_params=[\r\n" + str_rcv_par + "]\r\ntransmit_params=[\r\n" + str_trm_par + "]\r\n";

                sr.Close();

                //*
                save_file_dialog.Filter = "Comma separated files (*.ini)|*.ini";
                save_file_dialog.DefaultExt = "ini";
                save_file_dialog.AddExtension = true;
                if (save_files_path != null)
                {
                    save_file_dialog.InitialDirectory = load_files_path;
                }
                if (save_file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //rec_data_file_name = save_file_dialog.FileName;
                    var f1 = new System.IO.StreamWriter(save_file_dialog.FileName);
                    f1.Write(new_file);
                    f1.Close();
                    current_ini_content = new_file;
                    GetIniFile(current_ini_content);
                }
                //*/
            }
        }

        private void BintxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of1 = new OpenFileDialog
            {
                InitialDirectory = save_files_path,
                Filter = "Binary files (*.bin)|*.bin",
                DefaultExt = ".bin"
            };
            if (of1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var old_title = this.Text;

                this.Text += " (wait... converting in process...)";
                System.IO.BinaryReader hf_in = new System.IO.BinaryReader(System.IO.File.Open(of1.FileName, System.IO.FileMode.Open));
                System.IO.FileInfo fi = new System.IO.FileInfo(of1.FileName);

                byte[] byte_res = new byte[fi.Length];

                byte_res = hf_in.ReadBytes((int)fi.Length);
                hf_in.Close();

                SaveFileDialog sf1 = new SaveFileDialog
                {
                    InitialDirectory = save_files_path,
                    DefaultExt = ".csv",
                    Filter = "Comma separated values (*.csv)|*.csv",
                    AddExtension = true
                };

                if (sf1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ParseReceivedData(byte_res, true, sf1.FileName);
                }

                this.Text = old_title;
            }
        }
    }
}
