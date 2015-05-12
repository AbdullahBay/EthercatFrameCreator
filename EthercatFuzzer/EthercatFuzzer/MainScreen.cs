using System;
using System.Windows.Forms;
using PacketDotNet;
using System.Collections.Generic;
using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;
using System.Net.NetworkInformation;
using System.Drawing;
using SharpPcap;
using System.Globalization;


//Fixed coskun: Destination ve Source Adress "PhysicalAddress(desMACBytes)" tipinde gönderilecek
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
            txt_SourceAdress.Enabled = false;
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
            
            if (cmb_DeviceList.Text != "" && txt_DestinationAdress.Text != "" && txt_SourceAdress.Text != "")
            {
                MainScreenContract MainScreenData = new MainScreenContract();
                
                try
                {
                    MainScreenData.SelectedDeviceIndex = cmb_DeviceList.SelectedIndex;

                    SetDevice(cmb_DeviceList.SelectedIndex);
                    var S_macAddress            = SelectDevice.MacAddress;
                    var S_MACBytes              = S_macAddress.GetAddressBytes();
                    MainScreenData.SourceMac    = new PhysicalAddress(S_MACBytes);
                    SelectDevice.Close();

                    string DestMac        = txt_DestinationAdress.Text;
                    string Clear_DestMac  = DestMac.Replace(":", "");
                    string Clear_DestMac2 = Clear_DestMac.Replace(".", "");
                    MainScreenData.DestinationMac = StrictParseAddress(Clear_DestMac2);

                    
                    if (txt_RCount.Text == "")    { MainScreenData.RepeatCount = null; }
                    else                          { MainScreenData.RepeatCount = Convert.ToInt32(txt_RCount.Text); }

                    if (cmb_cmd.Text == "")       { MainScreenData.SelectedCmd = null; } 
                    else                          { MainScreenData.SelectedCmd = cmb_cmd.SelectedIndex; }

                    if (txt_SAddress.Text == "")  { MainScreenData.SlaveAddress = null; }
                    else                          { MainScreenData.SlaveAddress = Convert.ToInt16(txt_SAddress.Text); }

                    if (txt_OAddress.Text == "")  { MainScreenData.OffsetAddress = null; }
                    else                          { MainScreenData.OffsetAddress = Convert.ToInt16(txt_OAddress.Text); }

                    if (richtxt_data.Text == "")  {  MainScreenData.Data = null; }
                    else                          { MainScreenData.Data = richtxt_data.Text; }      

                }
                catch (Exception Ex) { MessageBox.Show(" Error :  " + Ex.Message); }

                // fixed abdullah: Contracktın gönderileceği gonksiyon yaılacak
                frame.Prepare(MainScreenData);
            }
            else MessageBox.Show("Please select the device and write source or destination address..");

        }


        public static PhysicalAddress StrictParseAddress(string address)
        {
            PhysicalAddress newAddress = PhysicalAddress.Parse(address);
            if (PhysicalAddress.None.Equals(newAddress))
                return null;

            return newAddress;
        }

        //Fixed coskun : Mac adresileri istenilen türe çevirilerek gönderilecek
        
        ICaptureDevice SelectDevice;
        private void cmb_DeviceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetDevice(cmb_DeviceList.SelectedIndex);
            var macAdress = SelectDevice.MacAddress;
            
            //txt_SourceAdress.Text = macAdress.ToString();
            txt_SourceAdress.Text = MacAddressParse(macAdress.ToString());
        }

        private void SetDevice(int selectedDeviceIndex)
        {
            // devivelerden kullandığını seçiliyor
            SelectDevice = CaptureDeviceList.Instance[selectedDeviceIndex];
            // kullanmak için aç
            SelectDevice.Open();
        }

        //Mac Adreslerinin TextBox için parse edildiği yer.
        string MacAddressParse(string MacAddress) 
        {
            string MACwithColons = "";
            for (int i = 0; i < MacAddress.ToString().Length; i++)
            {
                MACwithColons = MACwithColons + MacAddress.ToString().Substring(i, 2) + ":";
                i++;
            }
            MACwithColons = MACwithColons.Substring(0, MACwithColons.Length - 1);

            return MACwithColons;
        }


        private void txt_DestinationAdress_TextChanged(object sender, EventArgs e)
        {
            txt_DestinationAdress.BackColor = Color.OrangeRed;
            if (txt_DestinationAdress.Text.Length == 17)
            {
                txt_DestinationAdress.BackColor = Color.LightGreen;
            }
        }

        private void txt_SAddress_TextChanged(object sender, EventArgs e)
        {
            txt_SAddress.BackColor = Color.OrangeRed;
            if (txt_SAddress.Text.Length == 4)
            { txt_SAddress.BackColor = Color.LightGreen; }
            //else if (txt_OAddress.Text.Length != 4) { MessageBox.Show("Slave address must be 4 digits."); }
        }

        private void txt_OAddress_TextChanged(object sender, EventArgs e)
        {
            txt_OAddress.BackColor = Color.OrangeRed;
            if (txt_OAddress.Text.Length == 4) {txt_OAddress.BackColor = Color.LightGreen;}
            //else if (txt_OAddress.Text.Length != 4) { MessageBox.Show("Offset address must be 4 digits."); }
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
