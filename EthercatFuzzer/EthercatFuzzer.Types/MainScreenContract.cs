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

        private int slaveAddress;   //alt adres

        public int SlaveAddress
        {
            get { return slaveAddress; }
            set { slaveAddress = value; }
        }

        private int offsetAddress;   // karşı adress

        public int OffsetAddress
        {
            get { return offsetAddress; }
            set { offsetAddress = value; }
        }

        private string data;    //gönderilecek bilgi

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        



    }
}
