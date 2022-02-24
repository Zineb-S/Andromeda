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
    public partial class GroupsList : Form
    {
        public GroupsList()
        {
            Program.PreviousPage = "Group";
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            Program.liOfGroups.Clear();
            Group.importGroups(Program.liOfGroups);

            for (int i = 0; i < Program.liOfGroups.Count; i += 8)
            {
                flowLayoutPanel1.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfGroups[i]), Program.liOfGroups[i + 1].ToString(), Program.liOfGroups[i + 2].ToString(), Program.liOfGroups[i + 3].ToString(), "1", "1"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddGroup NGroup = new AddGroup();
            NGroup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void GroupsList_Load(object sender, EventArgs e)
        {

        }
    }
}
