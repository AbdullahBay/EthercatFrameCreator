using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;
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
            //fixed abdullah :legth bilgisi datagramların toplam byte sayısı ile doldurulacak.//ELength=80,
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

        public EtherCATPacked(MainScreenContract MainScreenData)
        {
            // fixed abdullah: Complete member initialization
            EtherCATDatagram datagram = new EtherCATDatagram()
            {
                Header = new DatagramHeader()
                {
                    Cmd=EtherCATHeaderList.CmdList.ElementAt(MainScreenData.SelectedCmd.GetValueOrDefault()).Code,
                    SlaveAddress=MainScreenData.SlaveAddress,
                    OffsetAddress=MainScreenData.OffsetAddress,
                },
                Data=MainScreenData.getDataAsByteArray()
            };
            List<EtherCATDatagram> datagrams = MultiplexDatagram(datagram, MainScreenData.RepeatCount);
            Datagrams.AddRange(datagrams);
            
        }

        private List<EtherCATDatagram> MultiplexDatagram(EtherCATDatagram datagram, int repeatCount)
        {
            List<EtherCATDatagram> returnList = new List<EtherCATDatagram>();
            for (int i = 0; i < repeatCount; i++)
            {
                returnList.Add(datagram);
            }
            return returnList;
        }


        public byte[] getBytes()
        {
            short dataLength=0;
            foreach (EtherCATDatagram datagram in Datagrams)
	        {
                dataLength = datagram.Length;
	        }
            Header.ELength = dataLength;
            byte[] etherCATDataAsBytes = new byte[Header.ELength];
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
