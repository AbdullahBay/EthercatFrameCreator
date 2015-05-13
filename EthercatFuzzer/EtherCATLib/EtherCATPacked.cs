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
            
          
            List<EtherCATDatagram> datagrams = MultiplexDatagram(MainScreenData);
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
        private List<EtherCATDatagram> MultiplexDatagram(MainScreenContract MainScreenData)
        {
            List<EtherCATDatagram> returnList = new List<EtherCATDatagram>();
            int repCount = MainScreenData.RepeatCount.GetValueOrDefault();
            for (int i = 0; i < repCount; i++)
            {
                EtherCATDatagram datagram = new EtherCATDatagram()
                {
                    Header = new DatagramHeader()
                    {
                        Cmd = EtherCATHeaderList.CmdList.ElementAt(MainScreenData.SelectedCmd.GetValueOrDefault()).Code,
                        SlaveAddress = MainScreenData.SlaveAddress.GetValueOrDefault(),
                        OffsetAddress = MainScreenData.OffsetAddress.GetValueOrDefault(),
                        Idx=BitConverter.GetBytes(i)[0]
                    },
                    Data = MainScreenData.getDataAsByteArray()
                };
                if (repCount - 1 != i)
                {
                    datagram.Header.SetMore();
                }
                else
                {
                    datagram.Header.More = 0;
                }
                returnList.Add(datagram);
            }
          
            return returnList;
        }


        public byte[] getBytes()
        {
            short dataLength=0;
            foreach (EtherCATDatagram datagram in Datagrams)
	        {
                dataLength+= datagram.Length;
	        }
            Header.ELength = dataLength;
            byte[] etherCATDataAsBytes = new byte[Header.ELength + 2];
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
