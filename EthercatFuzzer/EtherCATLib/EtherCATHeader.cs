using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherCATLib
{
    class EtherCATHeader
    {
       
        private Int16 eLen;

         public Int16 ELength
        {
            get { return eLen; }

            set { eLen = value; }
        }
         private byte eRes;

         public byte EReserved
         {
             get { return eRes; }
             set { eRes = value; }
         }
         private byte eType;

         public byte EType
         {
             get { return eType; }
             set { eType = value; }
         }

         public EtherCATHeader(Int16 ELength, byte EReserved, byte EType)
         {
             ELength = 62;
             EType = 1;
             EReserved = 0;

             this.ELength = ELength;
             this.EReserved = EReserved;
             this.EType = EType;

            
           //   Int16 hd = EReserved * Math.Pow(2, 11) + ELength + EType * Math.Pow(2, 12);
             //byte hd=0;
             //hd = EReserved.ToString(byte)*Math.Pow(2, 11) + ELength + EType * Math.Pow(2, 12);




         }
      
      
        
        
    }
}
