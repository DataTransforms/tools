using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Additional
using System.Net.Sockets;

namespace PortChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool IsPortOpen(string host, int port, TimeSpan timeout)
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

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);

            var isopen = IsPortOpen("localhost", 81, span);

            if (isopen)
            {
                button1.BackColor = Color.Green;
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }
    }
}
