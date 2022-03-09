using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda
{
    public partial class RequestBox : UserControl
    {
        
        public RequestBox(string Sender , string Receiver )
        {
            InitializeComponent();
            
            if ( Receiver == "your" )
            {
                BackColor = Color.LightBlue;
            }
            else
            {
                BackColor = Color.LightGreen;
            }
            
            label1.Text = Sender;
            label2.Text = " wants to explore " + Receiver +" planet. ";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RequestBox_Load(object sender, EventArgs e)
        {

        }
    }
}
