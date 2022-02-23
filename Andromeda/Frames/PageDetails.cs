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
    public partial class PageDetails : Form
    {
        public PageDetails(int PageID , string Title)
        {
            InitializeComponent();
            label1.Text = Title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPost post = new AddPost();
            post.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditPage editpage = new EditPage();
            editpage.Show();
        }

        private void PageDetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Pages pages = new Pages();
            pages.Show();
        }
    }
}
