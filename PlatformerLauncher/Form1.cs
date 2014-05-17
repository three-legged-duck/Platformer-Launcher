using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Resources;

namespace PlatformerLauncher
{
    public partial class LauncherForm : Form
    {
        //To move the windows
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //To get ressources from the form's resx
        private readonly ResourceManager _res = new ResourceManager(typeof (LauncherForm));

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {

        }

        private void LauncherForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        private void readmeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad", Application.StartupPath + @"\" + _res.GetString("readmeFile"));
            }
            catch
            {
                MessageBox.Show(_res.GetString("errorReadme"), _res.GetString("errorTitle"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + @"\setup.exe");
            }
            catch
            {
                MessageBox.Show(_res.GetString("errorSetup"), _res.GetString("errorTitle"),
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
