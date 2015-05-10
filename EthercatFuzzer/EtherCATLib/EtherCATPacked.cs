using EthercatFuzzer.Types;
using EthercatFuzzer.Types.FieldList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
         //TODO: yapıya uygun hale getir örn DatagramHeader.cs Propert Method Constructor
        #region Property
    public class EtherCATPacked
    {
        //TODO: Propfull a çek
        EtherCATHeader Header = new EtherCATHeader(){
            //fixed abdullah :legth bilgisi datagramların toplam byte sayısı ile doldurulacak.//ELength=80,
            EReserved=0,
            EType=1 //SOR TODO : ethercat typ alanında sadece 1 kabul ediyor
        };
        #endregion Property
        //TODO: Propfull a çek
        #region Constructor
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
        #endregion Constructor
        #region Method
        List<EtherCATDatagram> Datagrams = new List<EtherCATDatagram>();



        public void PrepareEthercatData()
        {
            int DATAGRAMSAYISI = 3;
            for (int i = 0; i < DATAGRAMSAYISI; i++)
            {
                Datagrams.Add(new EtherCATDatagram());
                if (DATAGRAMSAYISI - 1 != i)
                {
                    Datagrams[Datagrams.Count - 1].Header.SetMore();
                }
            }
        }



        public EtherCATPacked()
        {
            PrepareEthercatData();

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
            // data lar yükleniyor
            foreach (EtherCATDatagram datagram in Datagrams)
            {
                byte[] tempdatagramArray = datagram.GetBytes();

                for (int i = 0; i <tempdatagramArray.Length ; i++)
                {  
                    etherCATDataAsBytes[indis] = tempdatagramArray[i];
                    indis=indis+1;
                }
            }
            return etherCATDataAsBytes;
        }

    }
        #endregion Method
}
