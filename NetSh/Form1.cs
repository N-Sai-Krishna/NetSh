namespace NetSh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                MessageBox.Show(string.Concat(txtFileName.Text, " File already exists."));
                return;
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = "cmd.exe";
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;
            startInfo.Arguments = "/user:Administrator \"cmd /K netsh trace start capture=yes tracefile= " + txtFileName.Text + " persistent=yes\"";
            process.StartInfo = startInfo;
            process.Start();
            btnStop.Enabled = true;
            txtFileName.Text = string.Empty;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = "cmd.exe";
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;
            startInfo.Arguments = "/user:Administrator \"cmd /K netsh trace stop";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}