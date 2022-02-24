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
    public partial class AddMembers : Form
    {
        public AddMembers()
        {
            InitializeComponent();
           
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            Program.liOfnonMembers.Clear();
            User.importNONmembers(Program.liOfnonMembers);
            for (int i = 0; i < Program.liOfnonMembers.Count; i += 2)
            {

                flowLayoutPanel1.Controls.Add(new AddMemberBox(Program.liOfnonMembers[i].ToString(), Program.liOfnonMembers[i + 1].ToString()));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            switch(Program.PreviousPage)
            {
                case "Group":
                    GroupsList details = new GroupsList();
                    details.Show();
                    break;
                case "Event":
                    EventsList eventsList = new EventsList();
                    eventsList.Show();
                    break;

            }
            
        }

        private void AddMembers_Load(object sender, EventArgs e)
        {

        }
    }
}
