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
    public partial class AddComment : Form
    {
        public AddComment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 3la 7ssab dik lvariable globale anchufu wach andirigiw luser lgroup wla page wla event li fih dak lpost li zdna fih comment
            MessageBox.Show(" Comment Posted ");
            this.Hide();
            MainMenu menu  = new MainMenu();
            menu.Show();

        }
    }
}
