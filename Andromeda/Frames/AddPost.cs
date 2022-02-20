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
            String postTitle = textBoxPostTitle.Text;
            String postContent = textBoxPostContent.Text;
            Post.exportPosts(postTitle, postContent);
            this.Hide();
            PostsList newMenu = new PostsList();
            newMenu.Show();

            
            
        }

        private void AddPost_Load(object sender, EventArgs e)
        {
            
        }

        private void textBoxPostTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPostContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
