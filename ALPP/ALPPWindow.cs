using System.Runtime.InteropServices;

namespace ALPP
{
    public partial class ALPPWindow : Form
    {
        // nur fürs debuggen, da wir sowieso auf windows entwickeln
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        public ALPPWindow()
        {
            InitializeComponent();

            AllocConsole();
        }
    }
}
