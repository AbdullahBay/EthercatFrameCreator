using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    public class EtherCATPacked
    {
        //EtherCATData Data = new EtherCATData();
        EtherCATHeader Header = new EtherCATHeader(){
            //TODO:legth bilgisi datagramların toplam byte sayısı ile doldurulacak.
            ELength=80,
            EReserved=0,
            EType=1 //TODO : ethercat typ alanında sadece 1 kabul ediyor
        };

        
        List<EtherCATDatagram> Datagrams = new List<EtherCATDatagram>();



       public void PrepareEthercatData()
       {
           int DATAGRAMSAYISI=3;
           for (int i = 0; i < DATAGRAMSAYISI; i++)
           {
               Datagrams.Add(new EtherCATDatagram());
               if (DATAGRAMSAYISI-1!=i)
               {
                   
                       Datagrams[Datagrams.Count-1].Header.SetMore();
                       
               }
               
               
               
           }

       
       }
        
        
        
        public EtherCATPacked()
        {
            PrepareEthercatData();
            
        }

        public byte[] getBytes()
        {
            byte []etherCATDataAsBytes =new byte[250];
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
