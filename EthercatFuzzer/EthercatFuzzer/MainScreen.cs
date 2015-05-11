﻿using System;
using System.Windows.Forms;
using PacketDotNet;
using System.Collections.Generic;
using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;



namespace EthercatFuzzer
{
    //Fixed coskun: forma uygun bir isim verilmeli : MainScreen olabilir.  
    public partial class MainScreen : System.Windows.Forms.Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        
        EthernetSender frame;
        private void Form1_Load(object sender, System.EventArgs e)
        {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;  //Forum boyutlarını sabitleme

            frame = new EthernetSender();
            List<string> deviceList = EthernetSender.getDeviceList();
            foreach (var item in deviceList)
            {
                cmb_DeviceList.Items.Add(item);
            }

            List<CmdContract> CmdList = EtherCATHeaderList.CmdList;
            foreach (var item in CmdList)
            {
                cmb_cmd.Items.Add(item.Name);
            }
        }
        //Fixed coskun: device seçilmedi ise yada hiç yoksa gönder butonuna basınca uyarı verilecek
        private void button1_Click(object sender, System.EventArgs e)
        {
            
            //if (txt_RCount.Text != "" && cmb_DeviceList.Text != "" && cmb_cmd.Text != "" && txt_OAddress.Text != "" && richtxt_data.Text != "" && txt_OAddress.Text.Length == 4 && richtxt_data.Text.Length <= 100 && txt_SAddress.Text.Length == 4 )  // bütün boxların kontrolü
            
            if (cmb_DeviceList.Text != "")
            {
                MainScreenContract MainScreenData = new MainScreenContract();

                ////IP adres Konrolü
                //try{
                //    System.Net.IPAddress Slave_Address = System.Net.IPAddress.Parse(txt_SAddress.Text); // adresin parse edilmesi
                //    MainScreenData.SlaveAddress = Slave_Address.ToString(); // IP Adresinin gönderidiği yer
                //    //MessageBox.Show(Slave_Address.ToString());
                //    }
                //catch (FormatException) {MessageBox.Show("Wrong IP!");}

                try
                {

                    MainScreenData.SelectedDeviceIndex = cmb_DeviceList.SelectedIndex;
                    
                    // düzeltilecek
                    if (txt_RCount.Text == "") { MainScreenData.RepeatCount = Convert.ToInt32(txt_RCount.Text); }
                    else { MainScreenData.RepeatCount = Convert.ToInt32(txt_RCount.Text); }

                    if (cmb_cmd.Text == "") { cmb_cmd.Text = null; MainScreenData.SelectedCmd = cmb_cmd.SelectedIndex; } //düzeltilecek
                    else { MainScreenData.SelectedCmd = cmb_cmd.SelectedIndex; }

                    if (txt_SAddress.Text == "") { txt_SAddress.Text = null; MainScreenData.SlaveAddress = Convert.ToInt16(txt_SAddress.Text); }
                    else { MainScreenData.SlaveAddress = Convert.ToInt16(txt_SAddress.Text); }

                    if (txt_OAddress.Text == "") { txt_OAddress.Text = null; MainScreenData.OffsetAddress = Convert.ToInt16(txt_OAddress.Text); }
                    else { MainScreenData.OffsetAddress = Convert.ToInt16(txt_OAddress.Text); }

                    if (richtxt_data.Text == "") { richtxt_data.Text = null; MainScreenData.Data = richtxt_data.Text; }
                    else { MainScreenData.Data = richtxt_data.Text; }      
                    
  
                }
                catch (Exception Ex) { MessageBox.Show(" Error :  " + Ex.Message); }

                // fixed abdullah: Contracktın gönderileceği gonksiyon yaılacak
                //frame.Prepare(MainScreenData);

                //frame.Gonder(100, cmb_DeviceList.SelectedIndex);

            }
            else MessageBox.Show("Please select the device..");

            
        }



        private void cmb_DeviceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lbl_DeviceList_Click(object sender, System.EventArgs e)
        {

        }

    }
}