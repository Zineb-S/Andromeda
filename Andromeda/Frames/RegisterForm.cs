﻿using System;
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
            String fname = textBoxFirstname.Text;
            if (fname.Equals("first name"))
            {
                textBoxFirstname.Text = "";
            }

            String lname = textBoxLastname.Text;
            if (lname.Equals("last name"))
            {
                textBoxLastname.Text = "";
            }

            String username = textBoxEmail.Text;
            if (username.Equals("username"))
            {
                textBoxEmail.Text = "";
            }

            String email = textBoxUsername.Text;
            if (email.Equals("email address"))
            {
                textBoxUsername.Text = "";
            }

            String password = textBoxPassword.Text;
            if (password.Equals("password"))
            {
                textBoxPassword.Text = "";
            }

            String birthday = textBoxBirthDay.Text;
            if (birthday.Equals("Day"))
            {
                textBoxBirthDay.Text = "";
            }

            String birthmonth = textBoxBirthMonth.Text;
            if (birthmonth.Equals("Month"))
            {
                textBoxBirthMonth.Text = "";
            }

            String birthyear = textBoxBirthYear.Text;
            if (birthyear.Equals("Year"))
            {
                textBoxBirthYear.Text = "";
            }
        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            //add new user
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO users(User_Name, User_First_Name, User_Last_Name, User_Email, User_Password, Date_Of_Birth, Gender_Users) VALUES(@usn, @fn, @ln, @email, @pass,@year, @gender)", db.getConnection());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = textBoxBirthYear.Text + "-" + textBoxBirthMonth.Text + "-" + textBoxBirthDay.Text;
            command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = textBoxGender.Text;





            //open the connection
            db.openConnection();

            if (!checkTextBoxesValues())
            {
                //check if passwords are the same
                if (textBoxConfirmPassword.Text.Equals(textBoxPassword.Text))
                {
                    if (checkUsername(db))
                    {
                        MessageBox.Show("this username already exists");
                    }
                    else
                    {
                        //error date

                        {
                            string year = textBoxBirthYear.Text;
                            string day = textBoxBirthDay.Text;
                            string month = textBoxBirthMonth.Text;
                            if ((Int32.Parse(year) > 2022) || (Int32.Parse(day) > 31) || (Int32.Parse(month) > 12))
                            {
                                MessageBox.Show("ma3arefch fo9ach tzaditiii ??");
                            }
                            else
                            {
                                if (command.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Account created");

                                }
                                else
                                {

                                    MessageBox.Show("ERROR");
                                }
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("WRONG CONFIRM PASSWORD");
                }
            }
            else
            {
                MessageBox.Show("Enter all informations");
            }






            //check if the username already exists
            bool checkUsername(DB db2)
            {



                String username = textBoxEmail.Text;


                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM users WHERE User_Name = @usn", db.getConnection());

                command2.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;


                adapter.SelectCommand = command2;

                adapter.Fill(table);

                // check if the username already exists
                if (table.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }


            //check if the boxes are empty
            bool checkTextBoxesValues()
            {
                String fname = textBoxFirstname.Text;
                String lname = textBoxLastname.Text;
                String username = textBoxEmail.Text;
                String email = textBoxUsername.Text;
                String pass = textBoxPassword.Text;


                if (fname.Equals("first name") || lname.Equals("last name") || username.Equals("username") || email.Equals("email address") || pass.Equals("password"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            //close connection
            db.closeConnection();




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
    }
}