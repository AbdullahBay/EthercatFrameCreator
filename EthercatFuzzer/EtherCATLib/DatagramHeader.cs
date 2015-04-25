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
        private Int16 slaveAddress;

        public Int16 SlaveAddress
        {
            get { return slaveAddress; }
            set { slaveAddress = value; }
        }
        private Int16 offsetAddress;

        public Int16 OffsetAddress
        {
            get { return offsetAddress; }
            set { offsetAddress = value; }
        }
        private byte idx;

        public byte Idx
        {
            get { return idx; }
            set { idx = value; }
        }
        private byte cmd;

        public byte Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        private Int16 len;

        public Int16 Len
        {
            get { return len; }
            set { len = value; }
        }
        private byte res;

        public byte Res
        {
            get { return res; }
            set { res = value; }
        }
        private byte cr;

        public byte Cr
        {
            get { return cr; }
            set { cr = value; }
        }
        private byte more;

        public byte More
        {
            get { return more; }
            set { more = value; }
        }
        //TODO: irq ve Irq olmalı veya IRQ iRQ tarızında.
        private byte irq;

        public byte Irq
        {
            get { return irq; }
            set { irq = value; }
        }
        /// <summary>
        /// PArametresiz kurucu 
        /// TODO: parametersiz kurucununda kullanılabilmesi için set getler yazılmalı.
        /// </summary>
        public DatagramHeader()
        {

        }
        public DatagramHeader(byte Cmd,byte Idx,Int16 SlaveAddress, Int16 OffsetAddress,byte Len, byte Res,byte Cr, byte More,byte Irq)

         {
             this.Cmd = Cmd;
             this.Idx = Idx;
             this.SlaveAddress = SlaveAddress;
             this.OffsetAddress = OffsetAddress;
             this.Len = Len;
             this.Res = Res;
             this.Cr = Cr;
             this.More = More;
             this.Irq = Irq;

         }
        //TODO: fonksiyon tammalanacak
        public byte[] GetBytes()
        {
            byte []tempByteArray;
            byte[] returnByteArray=new byte[8]  ;

            returnByteArray[0] = Cmd;// ilk byte buraya gelecek;
            returnByteArray[1] = Idx; //sonra diğer byte
            tempByteArray = BitConverter.GetBytes(SlaveAddress);
            returnByteArray[2] = tempByteArray[0];
            returnByteArray[3] = tempByteArray[1];
            // sonra ki 2 byteye addresin ilk kısmı
            //burayada aderisin ikinci ksımı: örenk olarak yapıyorum;
            //  fix: temp arraya yeni değişken döndüğü için sadece 0 ve 1 indisleri dolu olcak.
            tempByteArray=BitConverter.GetBytes(OffsetAddress);
            returnByteArray[4] = tempByteArray[2]; // fix:[0]
            returnByteArray[5] = tempByteArray[3];  
          //  Int16 dataheader=Idx*TwoPow.eight+SlaveAddress+OffsetAddress+
                
             /*sonra gelen 16 bit bir gurup olduğu için önce çarpma işlemi ile 16 bit 
             * tammalanacak bir int oluşturulup ilk 2 bytesi gerekli byteye atanacak*/
            //int datagramheader= CMD+IDX*TwoPow.eight+Slave_Address*Two
            // sonolarak 8 bitlik alanzaten bytta tutuluyor oda oraya atuılacak.

            // ve 8 bytelik alanoluşturulduğu için döndürülecek.
            return returnByteArray;
        }
    }
}
