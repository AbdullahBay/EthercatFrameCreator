using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class EtherCATPacked
    {
        EtherCATHeader Header = new EtherCATHeader(){
            ELength=80,
            EReserved=0,
            EType=1
        };
        List<EtherCATDatagram> Datagrams = new List<EtherCATDatagram>();



       public void PrepareEthercatData()
       {

           EtherCATDatagram datagram = new EtherCATDatagram();

           Datagrams.Add(datagram);

       
       }
        
        
        
        public EtherCATPacked()
        {
            PrepareEthercatData();
            
        }

        public byte[] getBytes()
        {
            byte []etherCATDataAsBytes =new byte[160];
            byte[] ethercatHeader = Header.GetBytes();
            etherCATDataAsBytes[0] = ethercatHeader[0];
            etherCATDataAsBytes[1] = ethercatHeader[1];
            int indis=2;
            foreach (EtherCATDatagram datagram in Datagrams)
            {
                byte[] tempdatagramArray = datagram.GetBytes();

                for (int i = 0; i <tempdatagramArray.Length ; i++)
                {  
                    etherCATDataAsBytes[indis] = tempdatagramArray[i];
                    indis=indis+1;
                }
            }
            // data alanı örnek vei ile dolduruluyor
            /*
            for (int i = 2; i < etherCATDataAsBytes.Length; i++)
            {
                etherCATDataAsBytes[i] = 100;
            }*/
            return etherCATDataAsBytes;
        }
    }
}
