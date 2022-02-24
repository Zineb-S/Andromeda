using Andromeda.Frames;
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
    public partial class MemberBox : UserControl
    {
        public string IDusr = "";
        public string Name = "";
        public string MemberRole = "";
        public MemberBox(string ID , string Username, string role )
        {
            IDusr = ID;
            Name = Username;
            MemberRole = role;
            InitializeComponent();
            label3.Text = Username;
            label5.Text = role;


        }

        private void MemberBox_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMembers editm = new EditMembers();
            editm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User.DeleteMember(IDusr);
        }
    }
}
