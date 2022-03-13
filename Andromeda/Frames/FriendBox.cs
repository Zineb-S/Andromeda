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
    public partial class FriendBox : UserControl
    {
        public int UID = 0;
        public FriendBox(int id ,string username)
        {
            UID = id;
            InitializeComponent();
            label1.Text = username;
        }

        private void FriendBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request.RejectRequest(UID);
            FriendsList.ActiveForm.Dispose();
            FriendsList friendsList = new FriendsList();
            friendsList.Show();
                
                }
    }
}
