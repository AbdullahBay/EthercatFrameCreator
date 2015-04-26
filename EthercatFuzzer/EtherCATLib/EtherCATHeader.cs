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

             this.ELength = ELength;
             this.EReserved = EReserved;
             this.EType = EType;


         }
         public EtherCATHeader()
         {


         }



         internal byte[] GetBytes()
         {
             int headerAsInt = EReserved * TwoPow.eleven + ELength + EType * TwoPow.twelve;
             byte[] headerAsByte = BitConverter.GetBytes(headerAsInt);

             return new byte[] { headerAsByte[0], headerAsByte[1] };
         }
    }
}
