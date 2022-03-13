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
    public partial class Aliens : Form
    {
        public string nameLabel; 
        public string IDLabel;
        public Aliens(string ID , string name)  
        {
            nameLabel = name;
            IDLabel = ID;
            InitializeComponent();
            label1.Text = name;
        }

        private void Aliens_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Send_Message msg = new Send_Message(Convert.ToInt32(IDLabel));
            msg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Aliens.ActiveForm.Dispose();
            SearchPage search = new SearchPage();
            search.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PostsList posts = new PostsList();
            posts.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request.SendRequest(Program.CurrentUserID.ToString(),IDLabel);

        }
    }
}
