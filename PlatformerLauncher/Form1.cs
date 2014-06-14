using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
                Process.Start(CultureInfo.CurrentCulture.TwoLetterISOLanguageName.StartsWith("fr")
                    ? "manuel.html"
                    : "manual.html");
            }
            catch
            {
                string errorTitle, errorMessage;
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.StartsWith("fr"))
                {
                    errorTitle = "Erreur !";
                    errorMessage = "Impossible d'ouvrir le manuel.";
                }
                else
                {
                    errorTitle = "Error !";
                    errorMessage = "Unable to open the manual.";
                }
                MessageBox.Show(errorMessage, errorTitle,
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
                string errorTitle, errorMessage;
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.StartsWith("fr"))
                {
                    errorTitle = "Erreur !";
                    errorMessage = "Impossible d'ouvrir l'installeur.";
                }
                else
                {
                    errorTitle = "Error !";
                    errorMessage = "Unable to open the setup.";
                }
                MessageBox.Show(errorMessage, errorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}