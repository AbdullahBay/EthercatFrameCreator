using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthercatFuzzer.Types
{
    public class MainScreenContract
    {
        public MainScreenContract()
        {

        }
        //null atanmış ise random olduğu anlaşılacak.
        private int? selectedCmd;

        public int? SelectedCmd
        {
            get { return selectedCmd; }
            set { selectedCmd = value; }
        }

        //propfull yaz taba bas
        
    }
}
