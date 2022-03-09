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
    public partial class FriendsRequestList : Form
    {
        public FriendsRequestList()
        {
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            User.ImportRequests(Program.liOfRequests,Program.liOfReceivedRequests);
            for (int i = 0; i < Program.liOfRequests.Count; i+=4)
            {
                flowLayoutPanel1.Controls.Add(new RequestBox(Program.CurrentUserUsername, "Alien"));
            }
            for (int i = 0; i < Program.liOfReceivedRequests.Count; i += 4)
            {
                flowLayoutPanel1.Controls.Add(new RequestBox("Alien", "your"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void FriendsRequestList_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
