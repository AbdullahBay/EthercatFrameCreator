using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    class DatagramHeader
    {
        //TODO: public private isimlendirmesindeki değişiklik sadece baş harfle alakalıdır. Diğer harfler değiştirilmeyecekrtir örn:SlaveAddress ve slaveAddress şeklinde
        // TODO: sadece kelimlerin baş harfleri büyük olur alt tre kullanılmaz. Standardın adını hatırlayamadım :(
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
        //TODO: irq ve Irq olmalı veya IRQ iRQ tarızında.
        private byte irq;

        public byte IRQ
        {
            get { return more; }
            set { more = value; }
        }
        /// <summary>
        /// PArametresiz kurucu 
        /// TODO: parametersiz kurucununda kullanılabilmesi için set getler yazılmalı.
        /// </summary>
        public DatagramHeader()
        {

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
        //TODO: fonksiyon tammalanacak
        public byte[] GetBytes()
        {
            byte []tempByteArray;
            byte[] returnByteArray=new byte[8]  ;
            // ilk byte buraya gelecek;
            returnByteArray[0]=IDX;
            //sonra diğer byte
            // sonra ki 2 byteye addresin ilk kısmı
            //burayada aderisin ikinci ksımı: örenk olarak yapıyorum;
            tempByteArray=BitConverter.GetBytes(Offset_Address);
            returnByteArray[4] = tempByteArray[0];
            returnByteArray[5] = tempByteArray[1];
            /*sonra gelen 16 bit bir gurup olduğu için önce jarpma işlemi ile 16 bit 
             * tammalanacak bir int oluşturulup ilk 2 bytesi gerekli byteye atanacak*/
            //int datagramheader= CMD+IDX*TwoPow.eight+Slave_Address*Two
            // sonolarak 8 bitlik alanzaten bytta tutuluyor oda oraya atuılacak.

            // ve 8 bytelik alanoluşturulduğu için döndürülecek.
            return returnByteArray;
        }
    }
}
