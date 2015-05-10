using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthercatFuzzer.Types
{
    public class MainScreenContract
    {
        public MainScreenContract()
        {

        }
        //null atanmış ise random olduğu anlaşılacak.
        private int? selectedCmd;

        public int? SelectedCmd
        {
            get { return selectedCmd; }
            set { selectedCmd = value; }
        }

        //propfull yaz taba bas
        
        private int repeatCount;

        public int RepeatCount
        {
            get { return repeatCount; }
            set { repeatCount = value; }
        }
        

        private int deviceList;   //donanım listesi

        public int DeviceList
        {
            get { return deviceList; }
            set { deviceList = value; }
        }
        //fixed abdullah: Slave adres  ve offset tipi shorta çevirilecek
        private short slaveAddress;   //alt adres

        public short SlaveAddress
        {
            get { return slaveAddress; }
            set { slaveAddress = value; }
        }

        private short offsetAddress;   // karşı adress

        public short OffsetAddress
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
            get { return data; }
            set { data = value; }
        }
        
        //TODO: bu fonksiyo string olan datayı byte aray olarak dönmeli
        /// <summary>
        /// Data alanını byte array olarak döner
        /// </summary>
        /// <returns></returns>
        public byte[] getDataAsByteArray()
        {
            throw new NotImplementedException();
        }
        private static class MyRandom
        {
            // TODO Burada MainScreenContract ın tüm edeğişkenleri için random fonksiyon tanımlanacak
            // MainScreenContract get inde kullanılacak
            public static short  OffsetAddress()
            {
                return Convert.ToInt16((new Random()).Next(0,short.MaxValue));
            }
        }
    }
}
