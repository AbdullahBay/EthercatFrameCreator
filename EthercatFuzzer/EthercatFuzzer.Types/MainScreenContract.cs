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
        private int repeatCount ;

        public int RepeatCount
        {
            get { return RepeatCount; }
            set {RepeatCount  = value; }
        }

        private int deviceList;

        public int DeviceList
        {
            get { return deviceList; }
            set { deviceList = value; }
        }

        private int slaveAddress;

        public int SlaveAddress
        {
            get { return slaveAddress; }
            set { slaveAddress = value; }
        }

        private int offsetAddress;

        public int OffsetAddress
        {
            get { return offsetAddress; }
            set { offsetAddress = value; }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        




        public int repeatCount { get; set; }
    }
}
