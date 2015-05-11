using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketDotNet;
using PacketDotNet.Utils;
using SharpPcap;
using EtherCATLib;

namespace EthercatFuzzer
{
    //TODO: Bu sınıf soyutlanıp (sadece kedni işini yapar hale getirilipp) ethercat libe alınabilir diye düşünüyorum. işler bitince bakalım.
    //TODO Data nın ne olacağı ve DAtanın nasıl işleneceği ile alakalı çalışma yapmak lazım ilk testten sonra. datagramlar için
    class EthernetSender
    {
        static public byte [] ethernetBytes= new byte[100];
        static ByteArraySegment array = new ByteArraySegment(ethernetBytes);
        EthernetPacket ethernet;
        ICaptureDevice Selecteddev ;

        public EthernetSender()
        {
            
        }

        internal void Gonder(int kacKez, int selectedDeviceIndex  )
        {
            SetDevice(selectedDeviceIndex);
            PrepareMac();
            
            
            for (int i = 0; i < kacKez; i++)
            {
                Selecteddev.SendPacket(ethernet);
            }
            // gönderdikten sonra kapat
            Selecteddev.Close();
        }

        private void PrepareMac()
        {
            // hedef mec oluştur son byteyi değiştiriyor:19
            var desMAC = Selecteddev.MacAddress;
            var desMACBytes = desMAC.GetAddressBytes();
            desMACBytes[5] = 19;
            //paketi oluştur
            //System.Net.NetworkInformation.PhysicalAddress destmac = new System.Net.NetworkInformation.PhysicalAddress(desMACBytes);
            ethernet = new EthernetPacket(Selecteddev.MacAddress, new System.Net.NetworkInformation.PhysicalAddress(desMACBytes), EthernetPacketType.EtherCatProtocol);
            
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
            PrepareMac();
            var ethercatPacked= new EtherCATPacked(MainScreenData);
            ethernet.PayloadData = ethercatPacked.getBytes();
            for (int i = 0; i < 100; i++)
            {
                Selecteddev.SendPacket(ethernet);
            }
            // gönderdikten sonra kapat
            Selecteddev.Close();
        }
    }
}
