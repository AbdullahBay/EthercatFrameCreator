using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    class DatagramHeader
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
        private byte idx;

        public byte IDX
        {
            get { return idx; }
            set { idx = value; }
        }
        private byte cmd;

        public byte CMD
        {
            get { return cmd; }
            set { cmd = value; }
        }
        private Int16 len;

        public Int16 LEN
        {
            get { return len; }
            set { len = value; }
        }
        private byte res;

        public byte RES
        {
            get { return res; }
            set { res = value; }
        }
        private byte cr;

        public byte CR
        {
            get { return cr; }
            set { cr = value; }
        }
        private byte more;

        public byte MORE
        {
            get { return more; }
            set { more = value; }
        }
        private byte irq;

        public byte IRQ
        {
            get { return more; }
            set { more = value; }
        }

        public DatagramHeader(byte CMD,byte IDX,Int16 Slave_Address, Int16 Offset_Address,byte LEN, byte RES,byte CR, byte MORE,byte IRQ)

         {
             this.CMD = CMD;
             this.IDX = IDX;
             this.Slave_Address = Slave_Address;
             this.Offset_Address = Offset_Address;
             this.LEN = LEN;
             this.RES = RES;
             this.CR = CR;
             this.MORE = MORE;
             this.IRQ = IRQ;

         }
        //public byte[] GetBytes()
        //{
        //    //byte[] returnByteArray=new byte[8]  ;
        //    //returnByteArray[0]=
        //    //int datagramheader= CMD+IDX*TwoPow.eight+Slave_Address*TwoPow.
        //}
    }
}
