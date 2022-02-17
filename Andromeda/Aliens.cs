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
    public partial class Aliens : Form
    {
        public Aliens()
        {
            InitializeComponent();
        }

        private void Aliens_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Send_Message msg = new Send_Message();
            msg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PostsList posts = new PostsList();
            posts.Show();
        }
    }
}
