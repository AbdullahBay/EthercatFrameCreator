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
        DatagramHeader Header = new DatagramHeader(8,25,0,46,1,0,0,0,1);
        /// <summary>
        /// 10 bytelik dizi döndürür.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {   
           byte[] ReturnByteArray= new byte[10];
           ReturnByteArray = Header.GetBytes();
           return ReturnByteArray;

        }
        
        //TODO: get bytes array yazılacak;
    }
}
