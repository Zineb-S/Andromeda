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
        public int send = 0;
        public int recv = 0;
        public RequestBox(string SenderID,string Sender ,string ReceiverID, string Receiver )
        {
            send = Convert.ToInt32( SenderID );
            recv = Convert.ToInt32( ReceiverID );
            InitializeComponent();
            
            if ( Receiver == "your" )
            {
                BackColor = Color.LightBlue;
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                BackColor = Color.LightGreen;
                button1.Visible = false;
                button2.Visible = false;
            }
            
            label1.Text = Sender;
            label2.Text = " wants to explore " + Receiver +" planet. ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request.AcceptRequest(send);
            FriendsRequestList.ActiveForm.Dispose();
            FriendsRequestList friendsRequestList = new FriendsRequestList();
            friendsRequestList.Show();

        }
         
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RequestBox_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Request.RejectRequest(send);
            FriendsRequestList.ActiveForm.Dispose();
            FriendsRequestList friendsRequestList = new FriendsRequestList();
            friendsRequestList.Show();
        }
    }
}
