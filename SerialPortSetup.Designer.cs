namespace TarEmu3
{
    partial class SerialPortSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.port_settings_gp = new System.Windows.Forms.GroupBox();
            this.baud_rate_tb = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.ok_btn = new System.Windows.Forms.Button();
            this.parity_cb = new System.Windows.Forms.ComboBox();
            this.stop_bits_cb = new System.Windows.Forms.ComboBox();
            this.data_bits_cb = new System.Windows.Forms.ComboBox();
            this.stop_bits_lbl = new System.Windows.Forms.Label();
            this.parity_lbl = new System.Windows.Forms.Label();
            this.data_bits_lbl = new System.Windows.Forms.Label();
            this.com_port_cb = new System.Windows.Forms.ComboBox();
            this.baud_rate_lbl = new System.Windows.Forms.Label();
            this.com_port_lbl = new System.Windows.Forms.Label();
            this.serial_port1 = new System.IO.Ports.SerialPort(this.components);
            this.port_settings_gp.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_settings_gp
            // 
            this.port_settings_gp.Controls.Add(this.baud_rate_tb);
            this.port_settings_gp.Controls.Add(this.cancel_btn);
            this.port_settings_gp.Controls.Add(this.ok_btn);
            this.port_settings_gp.Controls.Add(this.parity_cb);
            this.port_settings_gp.Controls.Add(this.stop_bits_cb);
            this.port_settings_gp.Controls.Add(this.data_bits_cb);
            this.port_settings_gp.Controls.Add(this.stop_bits_lbl);
            this.port_settings_gp.Controls.Add(this.parity_lbl);
            this.port_settings_gp.Controls.Add(this.data_bits_lbl);
            this.port_settings_gp.Controls.Add(this.com_port_cb);
            this.port_settings_gp.Controls.Add(this.baud_rate_lbl);
            this.port_settings_gp.Controls.Add(this.com_port_lbl);
            this.port_settings_gp.Location = new System.Drawing.Point(1, 2);
            this.port_settings_gp.Name = "port_settings_gp";
            this.port_settings_gp.Size = new System.Drawing.Size(158, 214);
            this.port_settings_gp.TabIndex = 0;
            this.port_settings_gp.TabStop = false;
            this.port_settings_gp.Text = "Port settings";
            // 
            // baud_rate_tb
            // 
            this.baud_rate_tb.Location = new System.Drawing.Point(62, 48);
            this.baud_rate_tb.Name = "baud_rate_tb";
            this.baud_rate_tb.Size = new System.Drawing.Size(79, 20);
            this.baud_rate_tb.TabIndex = 12;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(81, 179);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(60, 21);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(5, 179);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(60, 22);
            this.ok_btn.TabIndex = 10;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // parity_cb
            // 
            this.parity_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parity_cb.FormattingEnabled = true;
            this.parity_cb.Location = new System.Drawing.Point(61, 128);
            this.parity_cb.Name = "parity_cb";
            this.parity_cb.Size = new System.Drawing.Size(80, 21);
            this.parity_cb.TabIndex = 9;
            // 
            // stop_bits_cb
            // 
            this.stop_bits_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stop_bits_cb.FormattingEnabled = true;
            this.stop_bits_cb.Location = new System.Drawing.Point(61, 101);
            this.stop_bits_cb.Name = "stop_bits_cb";
            this.stop_bits_cb.Size = new System.Drawing.Size(80, 21);
            this.stop_bits_cb.TabIndex = 8;
            // 
            // data_bits_cb
            // 
            this.data_bits_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.data_bits_cb.FormattingEnabled = true;
            this.data_bits_cb.Location = new System.Drawing.Point(61, 74);
            this.data_bits_cb.Name = "data_bits_cb";
            this.data_bits_cb.Size = new System.Drawing.Size(80, 21);
            this.data_bits_cb.TabIndex = 7;
            // 
            // stop_bits_lbl
            // 
            this.stop_bits_lbl.AutoSize = true;
            this.stop_bits_lbl.Location = new System.Drawing.Point(7, 104);
            this.stop_bits_lbl.Name = "stop_bits_lbl";
            this.stop_bits_lbl.Size = new System.Drawing.Size(48, 13);
            this.stop_bits_lbl.TabIndex = 5;
            this.stop_bits_lbl.Text = "Stop bits";
            // 
            // parity_lbl
            // 
            this.parity_lbl.AutoSize = true;
            this.parity_lbl.Location = new System.Drawing.Point(22, 131);
            this.parity_lbl.Name = "parity_lbl";
            this.parity_lbl.Size = new System.Drawing.Size(33, 13);
            this.parity_lbl.TabIndex = 4;
            this.parity_lbl.Text = "Parity";
            // 
            // data_bits_lbl
            // 
            this.data_bits_lbl.AutoSize = true;
            this.data_bits_lbl.Location = new System.Drawing.Point(7, 77);
            this.data_bits_lbl.Name = "data_bits_lbl";
            this.data_bits_lbl.Size = new System.Drawing.Size(49, 13);
            this.data_bits_lbl.TabIndex = 3;
            this.data_bits_lbl.Text = "Data bits";
            // 
            // com_port_cb
            // 
            this.com_port_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_port_cb.FormattingEnabled = true;
            this.com_port_cb.Location = new System.Drawing.Point(61, 19);
            this.com_port_cb.Name = "com_port_cb";
            this.com_port_cb.Size = new System.Drawing.Size(80, 21);
            this.com_port_cb.TabIndex = 2;
            // 
            // baud_rate_lbl
            // 
            this.baud_rate_lbl.AutoSize = true;
            this.baud_rate_lbl.Location = new System.Drawing.Point(2, 50);
            this.baud_rate_lbl.Name = "baud_rate_lbl";
            this.baud_rate_lbl.Size = new System.Drawing.Size(53, 13);
            this.baud_rate_lbl.TabIndex = 1;
            this.baud_rate_lbl.Text = "Baud rate";
            // 
            // com_port_lbl
            // 
            this.com_port_lbl.AutoSize = true;
            this.com_port_lbl.Location = new System.Drawing.Point(3, 22);
            this.com_port_lbl.Name = "com_port_lbl";
            this.com_port_lbl.Size = new System.Drawing.Size(52, 13);
            this.com_port_lbl.TabIndex = 0;
            this.com_port_lbl.Text = "COM-port";
            // 
            // SerialPortSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 215);
            this.Controls.Add(this.port_settings_gp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialPortSetup";
            this.Text = "Setup connection";
            this.Load += new System.EventHandler(this.SerialPortSetup_Load);
            this.port_settings_gp.ResumeLayout(false);
            this.port_settings_gp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox port_settings_gp;
        private System.Windows.Forms.Label baud_rate_lbl;
        private System.Windows.Forms.Label com_port_lbl;
        private System.IO.Ports.SerialPort serial_port1;
        private System.Windows.Forms.ComboBox com_port_cb;
        private System.Windows.Forms.ComboBox data_bits_cb;
        private System.Windows.Forms.Label stop_bits_lbl;
        private System.Windows.Forms.Label parity_lbl;
        private System.Windows.Forms.Label data_bits_lbl;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.ComboBox parity_cb;
        private System.Windows.Forms.ComboBox stop_bits_cb;
        private System.Windows.Forms.TextBox baud_rate_tb;
    }
}