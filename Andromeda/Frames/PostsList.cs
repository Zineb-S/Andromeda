﻿using System;
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
            Program.liOfProfilePosts.Clear();
            Program.PreviousPage = "Profile";
            Post.importProfilePosts(Program.liOfProfilePosts, Program.CurrentUserID, Program.CurrentUserProfileID);
            InitializeComponent();               
            postsPanel.FlowDirection = FlowDirection.TopDown;
            postsPanel.WrapContents = false;
            postsPanel.AutoScroll = true;
            postsPanel.Controls.Clear();    
            for (int i = 0;i<Program.liOfProfilePosts.Count;i+=7)
            {
         postsPanel.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfProfilePosts[i]),Program.liOfProfilePosts[i + 1].ToString(), Program.liOfProfilePosts[i + 2].ToString(), Program.liOfProfilePosts[i + 3].ToString(), Program.liOfProfilePosts[i + 4].ToString(), Convert.ToString(Program.liOfProfilePosts[i + 5])));
            }
           

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            postsPanel.Controls.Clear();
            this.Dispose();
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
