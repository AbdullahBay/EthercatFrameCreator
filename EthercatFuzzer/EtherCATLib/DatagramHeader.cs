using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class DatagramHeader
    {
        //fixed: public private isimlendirmesindeki değişiklik sadece baş harfle alakalıdır. Diğer harfler değiştirilmeyecekrtir örn:SlaveAddress ve slaveAddress şeklinde
        // fixed: sadece kelimlerin baş harfleri büyük olur alt tre kullanılmaz. Standardın adını hatırlayamadım :(
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
        //todo: leght hesapla : Ethercatdatagram.cs deki length yapısından faydalınalabilir
        /// <summary>
        /// Datagramın Data alnının  byte cinsinden uzunluğunu verir. 0-1486 byte
        /// </summary>
        private Int16 Len
        {
            get { return len; }
            set { len = value; }
        }
        private byte res;
        /// <summary>
        /// 3 bitlik değer alır kabul edilen tek değer 0 dır.
        /// </summary>
        public byte Res
        {
            get { return res; }
            set { res = value; }
        }
        //todo: Cr ne yapıyor
        //fix: cr alanı slaveler arası data alışverişi yapıp yapmadığını belirtiyor. Biz bunu 0 olarak alacağız.
        private byte cr=0;
        /// <summary>
        /// 1 bitlik bir değer alır
        /// </summary>
        public byte Cr
        {
            get { return cr; }
            set { cr = value; }
        }
        private byte more = 1;
        /// <summary>
        /// Devamında datagram var ise 1 alır. varsayılan 1 dır.
        /// </summary>
        public byte More
        {
            get { return more; }
            set { more = value; }
        }
        //TODO: hocaya  sor. Bir etherrcat paketindeki tüm irq lar aynı gibi.
        private byte irq;

        public byte Irq
        {
            get { return irq; }
            set { irq = value; }
        }
        /// <summary>
        /// PArametresiz kurucu 
        /// fixed abdullah: parametersiz kurucununda kullanılabilmesi için set getler yazılmalı. : gerek yok zaten property kullandık, set geti var
        /// </summary>
        public DatagramHeader()
        {

        }
        public void SetMore()
        {
            More = 1;
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
        //fixed nisa: fonksiyon tammalanacak 
        /// <summary>
        /// 10 byte lık bir dizi döndürür.
        /// </summary>
        /// <returns>byte Array</returns>
        public byte[] GetBytes()
        {
            byte []tempByteArray;
            byte[] returnByteArray=new byte[10]  ;
            returnByteArray[0] = Cmd;
            returnByteArray[1] = Idx; 
            tempByteArray = BitConverter.GetBytes(SlaveAddress);
                returnByteArray[2] = tempByteArray[0];
                returnByteArray[3] = tempByteArray[1];
            tempByteArray=BitConverter.GetBytes(OffsetAddress);
                returnByteArray[4] = tempByteArray[0]; 
                returnByteArray[5] = tempByteArray[1];
            //TODO: bu satırda hata mı var. moor çalışmıyor
            Int32 headerasint = Len + Res * TwoPow.eleven + Cr * TwoPow.twelve + More * TwoPow.thirteen;
            tempByteArray = BitConverter.GetBytes(headerasint);
                returnByteArray[6] = tempByteArray[0];
                returnByteArray[7] = tempByteArray[1];
            tempByteArray = BitConverter.GetBytes(Irq);
                returnByteArray[8] = tempByteArray[0];
                returnByteArray[9] = tempByteArray[1];
            return returnByteArray;
        }
    }
}
