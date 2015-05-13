using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketDotNet;
using PacketDotNet.Utils;
using SharpPcap;
using EtherCATLib;
using System.Net.NetworkInformation;

namespace EthercatFuzzer
{
    //TODO: Bu sınıf soyutlanıp (sadece kedni işini yapar hale getirilipp) ethercat libe alınabilir diye düşünüyorum. işler bitince bakalım.
    //TODO Data nın ne olacağı ve DAtanın nasıl işleneceği ile alakalı çalışma yapmak lazım ilk testten sonra. datagramlar için
    class EthernetSender
    {
        EthernetPacket ethernet;
        ICaptureDevice Selecteddev ;

        public EthernetSender()
        {
            
        }

        /*internal void Gonder(int kacKez, int selectedDeviceIndex  )
        {
            SetDevice(selectedDeviceIndex);
            PrepareMac();
            
            
            for (int i = 0; i < kacKez; i++)
            {
                Selecteddev.SendPacket(ethernet);
            }
            // gönderdikten sonra kapat
            Selecteddev.Close();
        }*/

        private void PrepareMac(PhysicalAddress SourceMac, PhysicalAddress DestinationMac)
        {
            
            //System.Net.NetworkInformation.PhysicalAddress destmac = new System.Net.NetworkInformation.PhysicalAddress(desMACBytes);
            ethernet = new EthernetPacket(SourceMac, DestinationMac, EthernetPacketType.EtherCatProtocol);
            
            // datayı pakete ekle

            //EtherCATPacked ethercatpaketi = new EtherCATPacked();
            //// ethercat datası yükleniyor
            //ethernet.PayloadData = ethercatpaketi.getBytes();
        }

        private void SetDevice(int selectedDeviceIndex)
        {
            //fized abdullah: Seçilmediyse kontrol et: kontrol arayğz tarafında yapılacak

            // devivelerden kullandığını seçiliyor
            Selecteddev = CaptureDeviceList.Instance[selectedDeviceIndex];
            // kullanmak için aç
            Selecteddev.Open();
        }
        public static List<String> getDeviceList()
        {
            List<string> deviceList = new List<string>();
            foreach (var item in CaptureDeviceList.Instance)
            {
                deviceList.Add(item.Description);
            }
            return deviceList;
        }


        internal void Prepare(Types.MainScreenContract MainScreenData)
        {
            SetDevice(MainScreenData.SelectedDeviceIndex);
            PrepareMac(MainScreenData.SourceMac,MainScreenData.DestinationMac);
            var ethercatPacked= new EtherCATPacked(MainScreenData);
            ethernet.PayloadData = ethercatPacked.getBytes();
            for (int i = 1; i < 20; i++)
            {
                Selecteddev.SendPacket(ethernet);
            }
            // gönderdikten sonra kapat
            Selecteddev.Close();
        }

    }
}
