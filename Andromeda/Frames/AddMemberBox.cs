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
    public partial class AddMemberBox : UserControl
    {
        public string IDstr = "";
        public AddMemberBox(string ID , string UserName )
        {
            InitializeComponent();
           label1.Text = UserName;
            IDstr = ID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.ExportMembers(IDstr,comboBox1.Text);
            MessageBox.Show("Member Added ");
            
        }

        private void AddMemberBox_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
