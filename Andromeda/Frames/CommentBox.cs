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
    public partial class CommentBox : UserControl
    {
        public CommentBox(int PostID,int commentID ,string username , string date , string content)
        {
            
            InitializeComponent();
            label5.Text = PostID.ToString();
            label4.Text = commentID.ToString();
            label1.Text = username;
            label2.Text = date; 
            label3.Text = content;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CommentsList.ActiveForm.Hide();
            EditComment editC = new EditComment(label3.Text,Convert.ToInt32(label4.Text), Convert.ToInt32(label5.Text));
            editC.Show();
        }

        private void CommentBox_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Comment.deleteComment(label4.Text);
            this.Dispose();
            
           
        }
    }
}
