using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    //TODO: yapıya uygun hale getir örn DatagramHeader.cs Propert Method Constructor
    
    public class EtherCATDatagram :ICloneable
    {
        #region Constructor
        public EtherCATDatagram()
        {
            Header = new DatagramHeader();
            Data = new byte[] { 255, 254, 253, 252, 251, 250 };
        }
        #endregion Constructor
        /// <summary>
        /// Standart header uzunluğunu döndürür. 10
        /// </summary>
        #region Propert

        private short HeaderLength { get { return 10; } } 
       
        private DatagramHeader header;
        private byte[] data;
        //TODO: paramerelerin public private ayarları yapılcak mesela length
        public DatagramHeader Header
        {
            get { return header; }
            set { header = value; }
        }
        
        public byte[] Data
        {
            get { return data; }
            set 
            { 
                data = value;
                Header.Len = Convert.ToInt16(data.Length);
            }
        }
        private short wCount;

        public short WCount
        {
            get { return wCount; }
            set { wCount = value; }
        }
        
        
       

        #endregion Propert
        /// <summary>
        /// 10 bytelik dizi döndürür.
        /// </summary>
        /// <returns></returns>
        #region Method,
       
        public byte[] GetBytes()
        {
           int DATALENGTH=Data.Length;
           byte[] ReturnByteArray= new byte[DATALENGTH+12];
           byte[] tmp=Header.GetBytes();
           int index = 0;
            foreach (var item in tmp)
            {
	            ReturnByteArray[index++] =item ;
            }
            for (int i = 0; i < DATALENGTH; i++)
            {
                ReturnByteArray[index++] = Data[i] ;
            }
            tmp = BitConverter.GetBytes(WCount);
            ReturnByteArray[index++] = tmp[0];
            ReturnByteArray[index++] = tmp[1];
           
           return ReturnByteArray;

        }
        
        //TODO: get bytes array yazılacak;
        /// <summary>
        /// Datagramın toplam byte uzunluğunu döner
        /// </summary>
        /// <returns>byte array</returns>
        public short Length { 
            get
            {
                return BitConverter.GetBytes(HeaderLength + Data.Length+2)[0];
            }
        }
        #endregion Method


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
