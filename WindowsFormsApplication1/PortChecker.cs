using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Me
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class PortChecker : Form
    {
        public PortChecker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Console.WriteLine("test");
            //System.Windows.Forms.MessageBox.Show("My message here");
        }
        private bool IsPortOpen(string host, int port, TimeSpan timeout)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(timeout);
                    if (!success)
                    {
                        return false;
                    }

                    client.EndConnect(result);
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);

            var port = 840;

            var portOpen = IsPortOpen("localhost", port, span);

            if (portOpen)
            {
                //System.Windows.Forms.MessageBox.Show("Port " + port + " is Open");
                button1.BackColor = Color.Green;
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("Port " + port + " is CLOSED");
                button1.BackColor = Color.Red;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
