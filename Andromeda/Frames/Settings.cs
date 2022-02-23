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
    public partial class Settings : Form
    {
        public Settings(string Username , string email , string password )
        {
            InitializeComponent();
            textBoxUsername.Text = Username;
            textBoxEmail.Text = email;
            textBoxConfirmPassword.Text = password;


        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            User.UpdateUser(textBoxUsername.Text,textBoxEmail.Text,textBoxPassword.Text,textBoxConfirmPassword.Text);
            this.Dispose();
         
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Profile newpfp = new Profile();
            newpfp.Show();
        }
    }
}
