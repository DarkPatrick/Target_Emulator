using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TarEmu3
{
    public partial class SerialPortSetup : Form
    {
        private static readonly string[] port_setting_names = { "Port settings", "Port name", "Baud rate", "Data bits", "Stop bits", "Parity" };
        public static UInt32 app_num;
        public static int com_port_name_idx;
        public static int baud_rate_val;
        public static int data_bits_idx;
        public static int stop_bits_idx;
        public static int parity_idx;
        public static string com_port_name_val;
        public static int data_bits_val;
        public static System.IO.Ports.StopBits stop_bits_val;
        public static System.IO.Ports.Parity parity_val;


        public SerialPortSetup()
        {
            InitializeComponent();
        }


        public void SerialPortInit()
        {
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                com_port_cb.Items.Add(s);
            }
            com_port_cb.SelectedIndex = 0;
            com_port_name_idx = 0;
            com_port_name_val = com_port_cb.SelectedItem.ToString();

            baud_rate_val = 921600;
            baud_rate_tb.Text = baud_rate_val.ToString();

            data_bits_cb.Items.Add(5);
            data_bits_cb.Items.Add(6);
            data_bits_cb.Items.Add(7);
            data_bits_cb.Items.Add(8);
            data_bits_cb.Items.Add(9);
            data_bits_cb.SelectedIndex = 3;
            data_bits_idx = 3;
            int.TryParse(data_bits_cb.GetItemText(data_bits_cb.SelectedItem), out data_bits_val);

            stop_bits_cb.Items.Add(0);
            stop_bits_cb.Items.Add(1);
            stop_bits_cb.Items.Add(2);
            stop_bits_cb.Items.Add(1.5);
            stop_bits_cb.SelectedIndex = 1;
            stop_bits_idx = 1;
            int.TryParse(stop_bits_cb.GetItemText(stop_bits_cb.SelectedItem), out int temp);
            stop_bits_val = (System.IO.Ports.StopBits)Enum.ToObject(typeof(System.IO.Ports.StopBits), temp);

            parity_cb.Items.Add("none");
            parity_cb.Items.Add("even");
            parity_cb.Items.Add("odd");
            parity_cb.Items.Add("mark");
            parity_cb.Items.Add("space");
            parity_cb.SelectedIndex = 0;
            parity_idx = 0;
            int.TryParse(parity_cb.GetItemText(parity_cb.SelectedItem), out temp);
            parity_val = (System.IO.Ports.Parity)Enum.ToObject(typeof(System.IO.Ports.Parity), temp);

            Microsoft.Win32.RegistryKey key;
            try
            {
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Target Emulator " + app_num.ToString()).OpenSubKey(port_setting_names[0]);
                int.TryParse(key.GetValue(port_setting_names[1]).ToString(), out int idx);
                com_port_cb.SelectedIndex = idx;
                com_port_name_idx = idx;
                com_port_name_val = com_port_cb.SelectedItem.ToString();
                baud_rate_tb.Text = key.GetValue(port_setting_names[2]).ToString();
                int.TryParse(key.GetValue(port_setting_names[3]).ToString(), out idx);
                data_bits_cb.SelectedIndex = idx;
                int.TryParse(key.GetValue(port_setting_names[4]).ToString(), out idx);
                stop_bits_cb.SelectedIndex = idx;
                int.TryParse(key.GetValue(port_setting_names[5]).ToString(), out idx);
                parity_cb.SelectedIndex = idx;
            }
            catch
            {
            }
        }


        private void SerialPortSetup_Load(object sender, EventArgs e)
        {
            SerialPortInit();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            com_port_name_idx = com_port_cb.SelectedIndex;
            int.TryParse(baud_rate_tb.Text, out baud_rate_val);
            data_bits_idx = data_bits_cb.SelectedIndex;
            stop_bits_idx = stop_bits_cb.SelectedIndex;
            parity_idx = parity_cb.SelectedIndex;

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Target Emulator " + app_num.ToString()).CreateSubKey(port_setting_names[0]);

            key.SetValue(port_setting_names[1], com_port_name_idx);
            key.SetValue(port_setting_names[2], baud_rate_val);
            key.SetValue(port_setting_names[3], data_bits_idx);
            key.SetValue(port_setting_names[4], stop_bits_idx);
            key.SetValue(port_setting_names[5], parity_idx);
            key.Close();

            this.Close();
        }
    }
}
