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
                new CmdContract(){Code=1,Abbreviation="APRD",Name="Auto Increment Read",Description="Slave increments address.Slave puts read data into the EtherCAT datagram if received address is zero."}
        };

    }
    public class CmdContract{
        public int Code;
        public String 
            Abbreviation,
            Name,
            Description;

    }
}
