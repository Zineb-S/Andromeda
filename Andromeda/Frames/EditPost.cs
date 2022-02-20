using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda.Frames
{
    public partial class EditPost : Form
    {
        public EditPost(int PostID,string OldTitle,string OldContent)
        {
            InitializeComponent();

            label3.Text = PostID.ToString();    
            BoxTitle.Text = OldTitle;
            BoxContent.Text = OldContent;
        }

        private void EditPost_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            String Title = BoxTitle.Text;
            String Content = BoxContent.Text;
            int PostID = Convert.ToInt32(label3.Text);
            Post.updatePost(PostID,Title, Content);
            this.Hide();
            PostsList newMenu = new PostsList();
            newMenu.Show();
        }
    }
}
