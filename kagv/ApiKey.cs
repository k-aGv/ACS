using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MessageBox.Show("The application will now restart in order for\n" +
                "the ApiKey you applied to be parsed.");
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
    }
}
