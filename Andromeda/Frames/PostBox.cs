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
    public partial class PostBox : UserControl
    {
        public PostBox(int PostID, string Title, string Date, string Content, string upVotes, string Downvotes)
        {
            
            
            InitializeComponent();
            
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(ContentLabel);
            label9.Text = PostID.ToString();
            ContentLabel.Text = Content;
            TitleLabel.Text = Title;
            label2.Text = Date;
            label6.Text = upVotes;
            label8.Text = Downvotes;

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            PostsList.postsPanel.Controls.Clear();
            int PostID = Convert.ToInt32(label9.Text);
            PostsList.ActiveForm.Dispose();
            EditPost editp = new EditPost( PostID );
            editp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            CommentsList cmtList = new CommentsList();
            cmtList.Show();
        }

        private void PostBox_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int PostID = Convert.ToInt32(label9.Text);
            Post.deletePost(PostID, Program.CurrentUserID);
            PostsList.ActiveForm.Dispose();
            PostsList newList = new PostsList();
            newList.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PostID = Convert.ToInt32(label9.Text);
            int CurrentVote = Convert.ToInt32(label6.Text);
            Post.UpVote(PostID, CurrentVote);
            CurrentVote++;
            label6.Text =CurrentVote.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int PostID = Convert.ToInt32(label9.Text);
            int CurrentVote = Convert.ToInt32(label8.Text);
            Post.DownVote(PostID, CurrentVote);
            CurrentVote++;
            label8.Text =CurrentVote.ToString();


        }
    }
}
