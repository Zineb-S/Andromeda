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
    public partial class PostsList : Form
    {
        public PostsList()
        {
            InitializeComponent();
            
            
            
            postsPanel.FlowDirection = FlowDirection.TopDown;
            postsPanel.WrapContents = false;
            postsPanel.AutoScroll = true;
            PostBox pb = new PostBox();
            PostBox nb = new PostBox();
            postsPanel.Controls.Add(pb);
            postsPanel.Controls.Add(nb);
            postsPanel.Controls.Add(nb);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPost NewPost = new AddPost();
            NewPost.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void PostsList_Load(object sender, EventArgs e)
        {

        }

        private void postsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
