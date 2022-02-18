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
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        private void AddPost_Load(object sender, EventArgs e)
        {
            
        }
    }
}
