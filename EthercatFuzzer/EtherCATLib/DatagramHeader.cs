using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class DatagramHeader
    {
        //fixed nisa: public private isimlendirmesindeki değişiklik sadece baş harfle alakalıdır. Diğer harfler değiştirilmeyecekrtir örn:SlaveAddress ve slaveAddress şeklinde
        // fixed nisa: sadece kelimlerin baş harfleri büyük olur alt tre kullanılmaz. Standardın adını hatırlayamadım :(

        
        #region Property

        #region private
 
        //varsayılan değerler burada atanır
        private Int16 slaveAddress;
        private Int16 offsetAddress;
        private byte idx;
        private byte cmd;
        private Int16 len;
        private byte cr = 0;
        private byte res;
        private byte more;
        private byte irq;

        #endregion private
        
        #region public

        public Int16 SlaveAddress
        {
            get { return slaveAddress; }
            set { slaveAddress = value; }
        }
        
        public Int16 OffsetAddress
        {
            get { return offsetAddress; }
            set { offsetAddress = value; }
        }
        
        public byte Idx
        {
            get { return idx; }
            set { idx = value; }
        }

        public byte Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        
        //fixed salih: leght hesapla : Ethercatdatagram.cs deki length yapısından faydalınalabilir: üst katmanda gerçekleştirildi
        /// <summary>
        /// Datagramın Data alnının  byte cinsinden uzunluğunu verir. 0-1486 byte
        /// </summary>
        public Int16 Len
        {
            get { return len; }
            set { len = value; }
        }
        
        /// <summary>
        /// 3 bitlik değer alır kabul edilen tek değer 0 dır.
        /// </summary>
        public byte Res
        {
            get { return res; }
            set { res = value; }
        }

        //SOR: Cr ne yapıyor
        //FORFUZZİNG: cr alanı slaveler arası data alışverişi yapıp yapmadığını belirtiyor. Biz bunu 0 olarak alacağız.

        /// <summary>
        /// 1 bitlik bir değer alır
        /// </summary>
        public byte Cr
        {
            get { return cr; }
            set { cr = value; }
        }
        
        /// <summary>
        /// Devamında datagram var ise 1 alır. varsayılan 1 dır.
        /// </summary>
        public byte More
        {
            get { return more; }
            set { more = value; }
        }

        //SOR TODO: hocaya  sor. Bir etherrcat paketindeki tüm irq lar aynı gibi.
        public byte Irq
        {
            get { return irq; }
            set { irq = value; }
        }
        #endregion public

        #endregion Property

        #region Constructor
        /// <summary>
        /// PArametresiz kurucu 
        /// fixed abdullah: parametersiz kurucununda kullanılabilmesi için set getler yazılmalı. : gerek yok zaten property kullandık, set geti var
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
        #endregion Constructor

        #region Method
        /// <summary>
        /// More Bitini 1 yapar
        /// </summary>
        public void SetMore()
        {
            More = 1;
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
            Int32 headerasint = Len + Res * TwoPow.eleven + Cr * TwoPow.forteen + More * TwoPow.fiveteen;
            tempByteArray = BitConverter.GetBytes(headerasint);
                returnByteArray[6] = tempByteArray[0];
                returnByteArray[7] = tempByteArray[1];
            tempByteArray = BitConverter.GetBytes(Irq);
                returnByteArray[8] = tempByteArray[0];
                returnByteArray[9] = tempByteArray[1];
            return returnByteArray;
        }
        #endregion Method
    }
}
