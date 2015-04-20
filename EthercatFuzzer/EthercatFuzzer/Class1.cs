using PacketDotNet;
using PacketDotNet.Utils;
using SharpPcap;
using EtherCATLib;

namespace EthercatFuzzer
{
   //////Silinecek taşındı

    class Class1
    {
        static public byte [] ethernetBytes= new byte[160];
        static ByteArraySegment array = new ByteArraySegment(ethernetBytes);
        EthernetPacket ethernet;
        ICaptureDevice selecteddev;
        public Class1  ()
        {
            
            // Retrieve all capture devices
            var devices = CaptureDeviceList.Instance;
            // devivelerden kullandığını seç
            selecteddev = devices[0];
            // göndermek için aç
            selecteddev.Open();
            // hedef mec oluştur son byteyi değiştiriyor:19
            var desMAC= selecteddev.MacAddress;
            var desMACBytes=desMAC.GetAddressBytes();
            desMACBytes[5]=19;
            //paketi oluştur
            System.Net.NetworkInformation.PhysicalAddress destmac = new System.Net.NetworkInformation.PhysicalAddress(desMACBytes);
            ethernet=new EthernetPacket(selecteddev.MacAddress,new System.Net.NetworkInformation.PhysicalAddress(desMACBytes),EthernetPacketType.EtherCatProtocol);
            // data oluştur
            for (int i = 0; i < 100; i++)
            {
                ethernetBytes[i] = 100;
            }
            // datayı pakete ekle

            EtherCATPacked ethercatpaketi=new EtherCATPacked();
            ethernet.PayloadData = ethercatpaketi.getBytes();
            // 100 kere gönder
            
            
        }



        internal void gonder()
        {
            for (int i = 0; i < 100; i++)
            {
                selecteddev.SendPacket(ethernet);
            }
        }
    }
}
