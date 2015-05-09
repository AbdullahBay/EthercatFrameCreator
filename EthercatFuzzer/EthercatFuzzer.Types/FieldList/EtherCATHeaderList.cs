using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthercatFuzzer.Types.FieldList
{
    public class EtherCATHeaderList
    {
        //TODO: Dökumandan cmd listsinin tamammı eklenecek.
        public  static List<CmdContract> CmdList = new List<CmdContract>(){
                new CmdContract(){Code=0,Abbreviation="NOP",Name="No Operation",Description="Slave ignores command"},
                new CmdContract(){Code=1,Abbreviation="APRD",Name="Auto Increment Read",Description="Slave increments address.Slave puts read data into the EtherCAT datagram if received address is zero."},
                new CmdContract(){Code=2,Abbreviation="APWR", Name="Auto Increment Write",Description="Slave increments address. Slave writes data into memory location if received address is zero."},
                new CmdContract(){Code=7,Abbreviation="BRD",Name="Broadcast Read", Description="All slaves put logical OR of data of the memory area and data of the EtherCAT datagram into the EtherCAT datagram. All slaves increment position field."},
                new CmdContract(){Code=8, Abbreviation="BWR",Name="Broadcast Write",Description="All slaves write data into memory location. All slaves increment position field."}

        };

    }
    public class CmdContract{
        private byte code;

        public byte Code
        {
            get { return code; }
            set { code = value; }
        }
        
        public String 
            Abbreviation,
            Name,
            Description;

    }
}
