using EthercatFuzzer.Types.FieldList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthercatFuzzer.Types
{
    //TODO: yapıya uygun hale getir örn DatagramHeader.cs Propert Method Constructor
    public class MainScreenContract
    {
        //TODO: randomu kontorol etmek için tüm alamnlar nullable yapılacak.  SelectedDeviceIndex hariç
        public MainScreenContract() {}
        //null atanmış ise random olduğu anlaşılacak.

        
         
        private int? selectedCmd;

        //TODO : Index üzerinden random değer atanılacak. 
        public int? SelectedCmd
        {
            get {
                if (selectedCmd == null) 
                {
                    return MyRandom.SelectedCmd();
                }
                
                return selectedCmd; 
                 }
            set { selectedCmd = value; }
        }

        //propfull yaz taba bas
        
        private int? repeatCount;

        public int? RepeatCount
        {
            get {
                if (repeatCount == null)
                {
                    return MyRandom.RepeatCount();
                }
                return repeatCount; 
            }
            set { repeatCount = value; }
        }
        

        private int selectedDeviceIndex;   //donanım listesi
        //Fixed coskun: adı SelectedDeviceIndex olacak
        //"Boş bırakılamaz" durumu olduğundan random söz konusu değil
        public int SelectedDeviceIndex
        {
            get { return selectedDeviceIndex; }
            set { selectedDeviceIndex = value; }
        }
        //fixed abdullah: Slave adres  ve offset tipi shorta çevirilecek

        private short? slaveAddress;   //alt adres


        public short? SlaveAddress
        {
            get {
                if (slaveAddress == null)
                {
                    return MyRandom.SlaveAdress();
                }
                
                return slaveAddress;
            }
            set { slaveAddress = value; }
        }

        private short? offsetAddress;   // karşı adress

        public short ?OffsetAddress
        {
            get 
            {
                if (offsetAddress==null)
                {
                    return MyRandom.OffsetAddress();
                } 
                //else
                return offsetAddress; 
            }
            set { offsetAddress = value; }
        }

        private string data;    //gönderilecek bilgi

        public string Data
        {
            get {
                if (data == null) 
                {

                    //int intValue = MyRandom.Data();
                    //byte[] intBytes = BitConverter.GetBytes(intValue);
                    //Array.Reverse(intBytes);
                    //byte[] result = intBytes;
                   // bit array return yazılacak 
                    return "asasd";
                }
                return data;
                }

            set { data = value; }
        }
        
        //fixed abdullah: bu fonksiyo string olan datayı byte array olarak dönmeli
        /// <summary>
        /// Data alanını byte array olarak döner
        /// </summary>
        /// <returns></returns>
        public byte[] getDataAsByteArray()
        {
            return Encoding.ASCII.GetBytes(Data);
        }

        private static class MyRandom
        {
            // TODO Burada MainScreenContract ın tüm edeğişkenleri için random fonksiyon tanımlanacak
            // MainScreenContract get inde kullanılacak
            public static short  OffsetAddress()
            {
                return Convert.ToInt16((new Random()).Next(0,short.MaxValue));
            }

            public static int RepeatCount()
            { 
                return Convert.ToInt16((new Random()).Next(0, 100));
            }

            public static short SlaveAdress()
            {
                return Convert.ToInt16((new Random()).Next(1000, 9999));
            }

            public static int Data()
            {
                return Convert.ToInt32((new Random()).Next(0, int.MaxValue));
            }
           
            public static int SelectedCmd()
            {
                List<CmdContract> CmdList = EtherCATHeaderList.CmdList;
                return Convert.ToInt32((new Random()).Next(0,CmdList.Count));
            }
        }
         
    }
}
