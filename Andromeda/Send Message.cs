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
    public partial class Send_Message : Form
    {
        public Send_Message()
        {
            InitializeComponent();
        }

        private void Send_Message_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Message Sent Succefully");
            this.Hide();
            Inbox Dms = new Inbox();
            Dms.Show();
        }
    }
}
