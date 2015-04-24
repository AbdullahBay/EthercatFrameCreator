using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class EtherCATPacked
    {
        EtherCATHeader Header = new EtherCATHeader(62,0,1);


       
        
        
        
        public EtherCATPacked()
        {
            
        }

        public byte[] getBytes()
        {
            byte []etherCATDataAsBytes =new byte[160];
            byte[] ethercatHeader = Header.GetBytes();
            etherCATDataAsBytes[0] = ethercatHeader[0];
            etherCATDataAsBytes[1] = ethercatHeader[1];
            // data alanı örnek vei ile dolduruluyor
            for (int i = 2; i < etherCATDataAsBytes.Length; i++)
            {
                etherCATDataAsBytes[i] = 100;
            }
            return etherCATDataAsBytes;
        }
    }
}
