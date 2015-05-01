using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    class EtherCATDatagram
    {
        //TODO: paramereleri verilecek
        public DatagramHeader Header = new DatagramHeader(8, 25, 0, 46, 1, 0, 0, 0, 1) 
        { 
            //TODO : datanın byte cinsinden uzunluğu
            Len=61
        };
        private byte[] data;

        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
        //TODO: WKC ne olacak bak sayfa 28
        private Int16 wkc=0;
        /// <summary>
        /// Working Counter: varsayılan değer 0 dır
        /// Read Command:Success +1
        /// Write Command:Success +1
        /// Read Wriete Command: Success Read: +1 Success Write: +2  Success Read Wriete: +3
        /// </summary>
        public Int16 Wkc
        {
            get { return wkc; }
            set { wkc = value; }
        }


        /// <summary>
        /// 10 bytelik dizi döndürür.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            int DATALENGTH = 61;
           byte[] ReturnByteArray= new byte[DATALENGTH+10];
           byte[] tmp=Header.GetBytes();
           int index = 0;
            foreach (var item in tmp)
            {
	            ReturnByteArray[index++] =item ;
            }
            for (int i = 0; i < DATALENGTH; i++)
            {
                ReturnByteArray[index++] =255 ;
            }
           
           return ReturnByteArray;

        }
        
        //TODO: get bytes array yazılacak;
    }
}
