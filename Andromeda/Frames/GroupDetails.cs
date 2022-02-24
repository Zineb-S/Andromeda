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
    public partial class GroupDetails : Form
    {
        public string T = "";
        public GroupDetails(string Title, string ID )
        {
            T = Title;
            InitializeComponent();
            label1.Text = Title;

            Program.PreviousPageID = Convert.ToInt32( ID );

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < Program.liOfGroupsPosts.Count; i += 7)
            {

                Program.VotesList.Clear();
                Vote.ImportPostVotes(Convert.ToInt32(Program.liOfGroupsPosts[i]), Program.VotesList);

                if (Program.VotesList.Count / 6 == 1)
                {

                    for (int j = 0; j < Program.VotesList.Count; j += 6)
                    {


                        flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfGroupsPosts[i]), Program.liOfGroupsPosts[i + 1].ToString(), Program.liOfGroupsPosts[i + 2].ToString(), Program.liOfGroupsPosts[i + 3].ToString(), Program.VotesList[j + 2].ToString(), Program.VotesList[j + 3].ToString(), Convert.ToInt32(Program.VotesList[j + 4]), Convert.ToInt32(Program.VotesList[j + 5])));
                    }
                }
                else
                {



                    flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfGroupsPosts[i]), Program.liOfGroupsPosts[i + 1].ToString(), Program.liOfGroupsPosts[i + 2].ToString(), Program.liOfGroupsPosts[i + 3].ToString(), "0", "0", 0, 0));

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPost post = new AddPost();
            post.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MembersList members = new MembersList();
            members.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupsList grpList = new GroupsList();
            grpList.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditGroup Editgrp = new EditGroup(T);
            Editgrp.Show();
        }

        private void GroupDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
