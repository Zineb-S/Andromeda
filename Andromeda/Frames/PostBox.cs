﻿using Andromeda.Frames;
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
        public PostBox( string Title ,string Date , string Content , string upVotes , string Downvotes)
        {
            InitializeComponent();

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(label4);
            label4.Text = Content;
            label3.Text = Title;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditPost editp = new EditPost();
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
    }
}
