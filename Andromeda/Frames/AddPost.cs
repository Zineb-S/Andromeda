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
    public partial class AddPost : Form
    {
        public AddPost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // hna andiro varible globale bach an3rfo lpost li tcreea fin anziduh wach lgroupe wla page wla event wla profile 
            MessageBox.Show("Post Added to hadik lvariable globale ");
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
