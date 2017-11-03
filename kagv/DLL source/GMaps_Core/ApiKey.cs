using System;
using System.Windows.Forms;
using System.IO;

namespace kagv
{
    public partial class ApiKey : Form
    {
        public ApiKey()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (File.Exists("apikey.txt"))
                File.Delete("apikey.txt");
            
            if (tb_ApiKey.Text == "")
            {
                MessageBox.Show("No ApiKey was inserted.");
                return;
            }
            StreamWriter _writer = new StreamWriter("apikey.txt");
            _writer.WriteLine(tb_ApiKey.Text);
            _writer.Close();
            DialogResult _result = 
            MessageBox.Show("The application will now restart in order for\n" +
                "the ApiKey you applied to be parsed.The key's validity will\n"+
                "be checked while using the API itself","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (_result == DialogResult.OK)
                Application.Restart();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://developers.google.com/maps/documentation/javascript/get-api-key");
        }

        private void ApiKey_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}
