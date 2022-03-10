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
    public partial class PageDetails : Form
    {
        
        public PageDetails( string Title,string PageID)
        {

            InitializeComponent();
            button1.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            if (Program.PreviousPage.Equals("Search"))

            {
                button1.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
              
       
            label1.Text = Title;

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < Program.liOfPagesPosts.Count; i += 7)
            {

                Program.VotesList.Clear();
                Vote.ImportPostVotes(Convert.ToInt32(Program.liOfPagesPosts[i]), Program.VotesList);

                if (Program.VotesList.Count / 6 == 1)
                {

                    for (int j = 0; j < Program.VotesList.Count; j += 6)
                    {


                        flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfPagesPosts[i]), Program.liOfPagesPosts[i + 1].ToString(), Program.liOfPagesPosts[i + 2].ToString(), Program.liOfPagesPosts[i + 3].ToString(), Program.VotesList[j + 2].ToString(), Program.VotesList[j + 3].ToString(), Convert.ToInt32(Program.VotesList[j + 4]), Convert.ToInt32(Program.VotesList[j + 5])));
                    }
                }
                else
                {



                    flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfPagesPosts[i]), Program.liOfPagesPosts[i + 1].ToString(), Program.liOfPagesPosts[i + 2].ToString(), Program.liOfPagesPosts[i + 3].ToString(), "0", "0", 0, 0));

                }
            }



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
            EditPage editpage = new EditPage(label1.Text);
            editpage.Show();
        }

        private void PageDetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.PreviousPage.Equals("Page"))
            {
                PageDetails.ActiveForm.Dispose();
                Pages pages = new Pages();
                pages.Show();
            }
             if (Program.PreviousPage.Equals("Search"))
             {
                 PageDetails.ActiveForm.Dispose();
                 SearchPage n = new SearchPage();
                 n.Show();

             }
           

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Page.deletePage(Program.PreviousPageID.ToString());
            this.Dispose();
            Pages pages2 = new Pages();
            pages2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
