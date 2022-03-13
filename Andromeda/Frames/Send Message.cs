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
    public partial class Send_Message : Form
    {
        public int received = 0;
        public Send_Message(int receiver)// get id of the user we are going to send a message to 
        {
            received = receiver;
            InitializeComponent();
        }

        private void Send_Message_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Message.SendMsg(received,textBox1.Text);  // param current user id , the one we gonna send it to and the content of the msg  
            this.Dispose();
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
