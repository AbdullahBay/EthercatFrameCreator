using System;
using System.Windows.Forms;
using PacketDotNet;
using System.Collections.Generic;
using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;



namespace EthercatFuzzer
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        EthernetSender frame;
        private void Form1_Load(object sender, System.EventArgs e)
        {
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

        private void button1_Click(object sender, System.EventArgs e)
        {

            if (txt_RCount.Text != "" && cmb_DeviceList.Text != "" && cmb_cmd.Text != "" && txt_OAddress.Text != "" && richtxt_data.Text != "" && txt_OAddress.Text.Length == 4 && richtxt_data.Text.Length <= 100 && txt_SAddress.Text.Length == 4 ) 
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
                    MainScreenData.DeviceList = cmb_DeviceList.SelectedIndex;        
                    MainScreenData.RepeatCount = Convert.ToInt32(txt_RCount.Text);
                    MainScreenData.SelectedCmd = cmb_cmd.SelectedIndex;                                      
                    MainScreenData.SlaveAddress = Convert.ToInt32(txt_SAddress.Text);      
                    MainScreenData.OffsetAddress = Convert.ToInt32(txt_OAddress.Text);     
                    MainScreenData.Data = richtxt_data.Text;                               
                }
                catch (Exception Ex) { MessageBox.Show(" Hata :  " + Ex.Message); }
                

                // TODO: Contracktın gönderileceği gonksiyon yaılacak
                 //Ofonksiyon(MainScreenData);

                //frame.Gonder(100, cmb_DeviceList.SelectedIndex);

            }
            else MessageBox.Show("Empty boxes found!");

            
        }



        private void cmb_DeviceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lbl_DeviceList_Click(object sender, System.EventArgs e)
        {

        }

    }
}
