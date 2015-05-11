using System;
using System.Windows.Forms;
using PacketDotNet;
using System.Collections.Generic;
using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;
using System.Net.NetworkInformation;
using System.Drawing;
using SharpPcap;


//TODO : Destination ve Source Adress "ethernet = new EthernetPacket(Selecteddev.MacAddress, new System.Net.NetworkInformation.PhysicalAddress(desMACBytes), EthernetPacketType.EtherCatProtocol);" tipinde gönderilecek
//Fixed coskun : Destination ve Source Adress Boş bırakılamaz ve elle girilmesi gerekiyor.
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
            
            if (cmb_DeviceList.Text != "" && txt_DestinationAdress.Text != "" && txt_SourceAdress.Text != "")
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
                    
                    if (txt_RCount.Text == "") { MainScreenData.RepeatCount = null; }
                    else { MainScreenData.RepeatCount = Convert.ToInt32(txt_RCount.Text); }

                    if (cmb_cmd.Text == "") { MainScreenData.SelectedCmd = null; } 
                    else { MainScreenData.SelectedCmd = cmb_cmd.SelectedIndex; }

                    if (txt_SAddress.Text == "") { MainScreenData.SlaveAddress = null; }
                    else { MainScreenData.SlaveAddress = Convert.ToInt16(txt_SAddress.Text); }

                    if (txt_OAddress.Text == "") { MainScreenData.OffsetAddress = null; }
                    else { MainScreenData.OffsetAddress = Convert.ToInt16(txt_OAddress.Text); }

                    if (richtxt_data.Text == "") {  MainScreenData.Data =null; }
                    else { MainScreenData.Data = richtxt_data.Text; }      
                    
                }
                catch (Exception Ex) { MessageBox.Show(" Error :  " + Ex.Message); }

                // fixed abdullah: Contracktın gönderileceği gonksiyon yaılacak
                frame.Prepare(MainScreenData);
            }
            else MessageBox.Show("Please select the device and write source or destination adress..");

        }


        ICaptureDevice SelectDevice;
        private void cmb_DeviceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetDevice(cmb_DeviceList.SelectedIndex);
            var macAdress = SelectDevice.MacAddress;
            txt_SourceAdress.Text = macAdress.ToString();
        }

        private void SetDevice(int selectedDeviceIndex)
        {
            // devivelerden kullandığını seçiliyor
            SelectDevice = CaptureDeviceList.Instance[selectedDeviceIndex];
            // kullanmak için aç
            SelectDevice.Open();
        }


        private void lbl_DeviceList_Click(object sender, System.EventArgs e)
        {

        }




        //static string GetMacAddress()
        //{
        //    string macAddresses = "";
        //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //    {
        //        // Only consider Ethernet network interfaces, thereby ignoring any
        //        // loopback devices etc.
        //        if (nic.NetworkInterfaceType != 
        //            continue;
        //        if (nic.OperationalStatus == OperationalStatus.Up)
        //        {
        //            macAddresses += nic.GetPhysicalAddress().ToString();
        //            break;
        //        }
        //    }
        //    return macAddresses;
        //}






    }
}
