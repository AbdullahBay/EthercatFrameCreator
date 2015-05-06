namespace EthercatFuzzer
{
    partial class Form1
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
            this.btn_send = new System.Windows.Forms.Button();
            this.lbl_DeviceList = new System.Windows.Forms.Label();
            this.cmb_DeviceList = new System.Windows.Forms.ComboBox();
            this.lbl_RepeatCount = new System.Windows.Forms.Label();
            this.txt_RCount = new System.Windows.Forms.TextBox();
            this.lbl_CMD = new System.Windows.Forms.Label();
            this.cmb_cmd = new System.Windows.Forms.ComboBox();
            this.lbl_SlaveAddress = new System.Windows.Forms.Label();
            this.lbl_OffsetAddress = new System.Windows.Forms.Label();
            this.txt_OAddress = new System.Windows.Forms.TextBox();
            this.lbl_Data = new System.Windows.Forms.Label();
            this.txt_SAddress = new System.Windows.Forms.TextBox();
            this.richtxt_data = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(310, 230);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(152, 23);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_DeviceList
            // 
            this.lbl_DeviceList.AutoSize = true;
            this.lbl_DeviceList.Location = new System.Drawing.Point(27, 28);
            this.lbl_DeviceList.Name = "lbl_DeviceList";
            this.lbl_DeviceList.Size = new System.Drawing.Size(60, 13);
            this.lbl_DeviceList.TabIndex = 1;
            this.lbl_DeviceList.Text = "Device List";
            this.lbl_DeviceList.Click += new System.EventHandler(this.lbl_DeviceList_Click);
            // 
            // cmb_DeviceList
            // 
            this.cmb_DeviceList.FormattingEnabled = true;
            this.cmb_DeviceList.Location = new System.Drawing.Point(141, 25);
            this.cmb_DeviceList.Name = "cmb_DeviceList";
            this.cmb_DeviceList.Size = new System.Drawing.Size(190, 21);
            this.cmb_DeviceList.TabIndex = 2;
            this.cmb_DeviceList.SelectedIndexChanged += new System.EventHandler(this.cmb_DeviceList_SelectedIndexChanged);
            // 
            // lbl_RepeatCount
            // 
            this.lbl_RepeatCount.AutoSize = true;
            this.lbl_RepeatCount.Location = new System.Drawing.Point(27, 82);
            this.lbl_RepeatCount.Name = "lbl_RepeatCount";
            this.lbl_RepeatCount.Size = new System.Drawing.Size(73, 13);
            this.lbl_RepeatCount.TabIndex = 3;
            this.lbl_RepeatCount.Text = "Repeat Count";
            // 
            // txt_RCount
            // 
            this.txt_RCount.Location = new System.Drawing.Point(141, 75);
            this.txt_RCount.Name = "txt_RCount";
            this.txt_RCount.Size = new System.Drawing.Size(190, 20);
            this.txt_RCount.TabIndex = 4;
            // 
            // lbl_CMD
            // 
            this.lbl_CMD.AutoSize = true;
            this.lbl_CMD.Location = new System.Drawing.Point(27, 134);
            this.lbl_CMD.Name = "lbl_CMD";
            this.lbl_CMD.Size = new System.Drawing.Size(31, 13);
            this.lbl_CMD.TabIndex = 5;
            this.lbl_CMD.Text = "CMD";
            // 
            // cmb_cmd
            // 
            this.cmb_cmd.FormattingEnabled = true;
            this.cmb_cmd.Location = new System.Drawing.Point(141, 126);
            this.cmb_cmd.Name = "cmb_cmd";
            this.cmb_cmd.Size = new System.Drawing.Size(190, 21);
            this.cmb_cmd.TabIndex = 6;
            // 
            // lbl_SlaveAddress
            // 
            this.lbl_SlaveAddress.AutoSize = true;
            this.lbl_SlaveAddress.Location = new System.Drawing.Point(27, 185);
            this.lbl_SlaveAddress.Name = "lbl_SlaveAddress";
            this.lbl_SlaveAddress.Size = new System.Drawing.Size(75, 13);
            this.lbl_SlaveAddress.TabIndex = 7;
            this.lbl_SlaveAddress.Text = "Slave Address";
            // 
            // lbl_OffsetAddress
            // 
            this.lbl_OffsetAddress.AutoSize = true;
            this.lbl_OffsetAddress.Location = new System.Drawing.Point(27, 239);
            this.lbl_OffsetAddress.Name = "lbl_OffsetAddress";
            this.lbl_OffsetAddress.Size = new System.Drawing.Size(76, 13);
            this.lbl_OffsetAddress.TabIndex = 9;
            this.lbl_OffsetAddress.Text = "Offset Address";
            // 
            // txt_OAddress
            // 
            this.txt_OAddress.Location = new System.Drawing.Point(141, 232);
            this.txt_OAddress.Name = "txt_OAddress";
            this.txt_OAddress.Size = new System.Drawing.Size(100, 20);
            this.txt_OAddress.TabIndex = 10;
            // 
            // lbl_Data
            // 
            this.lbl_Data.AutoSize = true;
            this.lbl_Data.Location = new System.Drawing.Point(30, 285);
            this.lbl_Data.Name = "lbl_Data";
            this.lbl_Data.Size = new System.Drawing.Size(30, 13);
            this.lbl_Data.TabIndex = 11;
            this.lbl_Data.Text = "Data";
            // 
            // txt_SAddress
            // 
            this.txt_SAddress.Location = new System.Drawing.Point(141, 178);
            this.txt_SAddress.Name = "txt_SAddress";
            this.txt_SAddress.Size = new System.Drawing.Size(190, 20);
            this.txt_SAddress.TabIndex = 13;
            // 
            // richtxt_data
            // 
            this.richtxt_data.Location = new System.Drawing.Point(141, 282);
            this.richtxt_data.Name = "richtxt_data";
            this.richtxt_data.Size = new System.Drawing.Size(321, 69);
            this.richtxt_data.TabIndex = 14;
            this.richtxt_data.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 363);
            this.Controls.Add(this.richtxt_data);
            this.Controls.Add(this.txt_SAddress);
            this.Controls.Add(this.lbl_Data);
            this.Controls.Add(this.txt_OAddress);
            this.Controls.Add(this.lbl_OffsetAddress);
            this.Controls.Add(this.lbl_SlaveAddress);
            this.Controls.Add(this.cmb_cmd);
            this.Controls.Add(this.lbl_CMD);
            this.Controls.Add(this.txt_RCount);
            this.Controls.Add(this.lbl_RepeatCount);
            this.Controls.Add(this.cmb_DeviceList);
            this.Controls.Add(this.lbl_DeviceList);
            this.Controls.Add(this.btn_send);
            this.Name = "Form1";
            this.Text = "EtherCAT Fuzzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label lbl_DeviceList;
        private System.Windows.Forms.ComboBox cmb_DeviceList;
        private System.Windows.Forms.Label lbl_RepeatCount;
        private System.Windows.Forms.TextBox txt_RCount;
        private System.Windows.Forms.Label lbl_CMD;
        private System.Windows.Forms.ComboBox cmb_cmd;
        private System.Windows.Forms.Label lbl_SlaveAddress;
        private System.Windows.Forms.Label lbl_OffsetAddress;
        private System.Windows.Forms.TextBox txt_OAddress;
        private System.Windows.Forms.Label lbl_Data;
        private System.Windows.Forms.TextBox txt_SAddress;
        private System.Windows.Forms.RichTextBox richtxt_data;
    }
}

