using Andromeda.Entities;
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
        public Boolean Like ; // Use the values imported from the post votes 
        public Boolean Dislike ;
        public PostBox(int PostID, string Title, string Date, string Content, string upVotes, string Downvotes , int L,int DL)
        {
            InitializeComponent();
            Console.WriteLine(PostID + " : " + L + " " + DL);
            if (L == 0 & DL == 0)
            {
                Like = false;
                Dislike = false;
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
            }
            else
            {
                if (L == 0)
                {
                    Like = false;
                    Dislike = true;
                    button1.BackColor = Color.LightCoral;
                }
                else if (DL == 0)
                {
                    Dislike = false;
                    Like = true;
                    button2.BackColor = Color.LightGreen;
                }
            }
           
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
          
            int PostID = Convert.ToInt32(label9.Text);
            PostsList.ActiveForm.Hide();
            EditPost editp = new EditPost( PostID ,TitleLabel.Text.ToString(),ContentLabel.Text);
            editp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int PostID = Convert.ToInt32(label9.Text);
            CommentsList cmtList = new CommentsList(PostID);
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
            
            
            if (Dislike==false)
            {
                switch (Like)
                {
                    case true:
                        Like = false;
                        label6.Text = (Convert.ToInt32(label6.Text)-1).ToString();
                        break;
                    case false:
                        Like = true;
                        label6.Text = (Convert.ToInt32(label6.Text) + 1).ToString();
                        Vote.exportPostVotes(label9.Text, "Like");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please Remove your dislike first :) ");
            }
            if (Like == true)
            {
                button2.BackColor = Color.LightGreen;
            }
            else
            {
                button2.BackColor = Color.White;
            }

            
     

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Like == false)
            {
                switch (Dislike)
                {
                    case false:
                        Dislike = true;
                        label8.Text = (Convert.ToInt32(label8.Text) + 1).ToString();
                        Vote.exportPostVotes(label9.Text, "Dislike");
                        break;
                    case true:
                        Dislike = false;
                        label8.Text = (Convert.ToInt32(label8.Text) - 1).ToString();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please Remove your like first :( ");
            }
            if (Dislike == true)
            {
                button1.BackColor = Color.LightCoral;
            }
            else
            {
                button1.BackColor = Color.White;
            }
            
         


        }
    }
}
