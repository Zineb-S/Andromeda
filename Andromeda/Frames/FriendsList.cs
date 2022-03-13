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
    public partial class FriendsList : Form
    {
        public FriendsList()
        {
            Program.liOfReceivedRequests.Clear();
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();

            Request.ImportRequests(Program.liOfRequests, Program.liOfReceivedRequests);
            for (int i = 0; i < Program.liOfReceivedRequests.Count; i += 6)
            {
                int val = Convert.ToInt32(Program.liOfReceivedRequests[i + 5]);
                if (val == 1)
                {
                    flowLayoutPanel1.Controls.Add(new FriendBox(Convert.ToInt32(Program.liOfReceivedRequests[i + 1]),Program.liOfReceivedRequests[i + 2].ToString()));
                    
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FriendsList_Load(object sender, EventArgs e)
        {

        }
    }
}
