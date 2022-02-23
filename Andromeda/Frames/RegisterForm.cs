using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Andromeda
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            
        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            string fname = textBoxFirstname.Text;
            string lname = textBoxLastname.Text;
            string username = textBoxUsername.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string passwordconfirm = textBoxConfirmPassword.Text;
            string year = textBoxBirthYear.Text;
            string month = textBoxBirthMonth.Text;
            string day =  textBoxBirthDay.Text;
            string date = textBoxBirthYear.Text + "-" + textBoxBirthMonth.Text + "-" + textBoxBirthDay.Text;
            string gender = textBoxGender.Text;


            User.exportUsers(fname, lname, username, email, password, passwordconfirm, year,month ,day , date, gender);
             
    
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void textBoxLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBirthMonth_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
