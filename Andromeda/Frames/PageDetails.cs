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
    public partial class PageDetails : Form
    {
        public PageDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPost post = new AddPost();
            post.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
