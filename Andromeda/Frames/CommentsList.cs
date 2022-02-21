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
    public partial class CommentsList : Form
    {
        public CommentsList(int PostID)
        {
            Program.liOfPostsComments.Clear();
            Comment.importPostsComments(PostID,Program.liOfPostsComments);
            InitializeComponent();
            label2.Text = PostID.ToString();
            CommentsPanel.FlowDirection = FlowDirection.TopDown;
            CommentsPanel.WrapContents = false;
            CommentsPanel.AutoScroll = true;
            CommentsPanel.Controls.Clear();
            Console.WriteLine(Program.liOfPostsComments.Count);
            for (int i = 0; i < Program.liOfPostsComments.Count; i += 5)
            {
                CommentsPanel.Controls.Add(new CommentBox(PostID,Convert.ToInt32(Program.liOfPostsComments[i]), Program.liOfPostsComments[i + 4].ToString(), Program.liOfPostsComments[i + 2].ToString(), Program.liOfPostsComments[i+1].ToString()));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            this.Hide();
            AddComment comment = new AddComment(Int32.Parse(label2.Text));
            comment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CommentsList_Load(object sender, EventArgs e)
        {

        }
    }
}
