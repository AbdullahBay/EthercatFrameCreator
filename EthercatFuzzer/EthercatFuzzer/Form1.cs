

using PacketDotNet;

namespace EthercatFuzzer
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class1 c = new Class1();
        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            c.gonder();
        }
    }
}
