using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class EtherCATPacked
    {
        private Int16 slave_address;

        public Int16 Slave_Address
        {
            get { return slave_address; }
            set { slave_address = value; }
        }
        private Int16 offset_address;

        public Int16 Offset_Address
        {
            get { return offset_address; }
            set { offset_address = value; }
        }
        private byte index;

        public byte INDEX
        {
            get { return index; }
            set { index = value; }
        }
        private byte cmd;

        public byte CMD
        {
            get { return cmd; }
            set { cmd = value; }
        }
        private Int16 length;

        public Int16 LENGTH
        {
            get { return length; }
            set { length = value; }
        }
       
        
        
        
        public EtherCATPacked()
        {
            
        }

        public byte[] getBytes()
        {
            throw new NotImplementedException();
        }
    }
}
