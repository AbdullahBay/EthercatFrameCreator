using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class EtherCATPacked
    {
        
       
        
        
        
        public EtherCATPacked()
        {
            
        }

        public byte[] getBytes()
        {
            byte []etherCATDataAsBytes =new byte[160];
            // data alanı örnek vei ile dolduruluyor
            for (int i = 0; i < etherCATDataAsBytes.Length; i++)
            {
                etherCATDataAsBytes[i] = 100;
            }
            return etherCATDataAsBytes;
        }
    }
}
