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
    public partial class MembersList : Form
    {
        
        public MembersList()
        {
            InitializeComponent();
           
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            Program.liOfGroupMembers.Clear();
            Program.liOfEventMembers.Clear();
            switch(Program.PreviousPage)
            {
                case "Group":
                    User.ImportGroupMembers(Program.liOfGroupMembers);
                    for (int i = 0; i < Program.liOfGroupMembers.Count; i+=4)
                    {
                        flowLayoutPanel2.Controls.Add(new MemberBox(Program.liOfGroupMembers[i+1].ToString(), Program.liOfGroupMembers[i+2].ToString(), Program.liOfGroupMembers[i+3].ToString()));
                    }
                    break;
                case "Event":
                    User.ImportEventMembers(Program.liOfEventMembers);
                    for (int i = 0; i < Program.liOfEventMembers.Count; i+=4)
                    {
                        flowLayoutPanel2.Controls.Add(new MemberBox(Program.liOfEventMembers[i+1].ToString(), Program.liOfEventMembers[i+2].ToString(), Program.liOfEventMembers[i+3].ToString()));
                    }
                    break ;
            }
            
            
            
        }

        private void MembersList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMembers NMember = new AddMembers();
            NMember.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
