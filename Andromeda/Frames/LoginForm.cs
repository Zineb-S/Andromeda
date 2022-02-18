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
    public partial class LoginForm : Form
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            String email = textBoxEmail.Text;
            String password = textBoxPassword.Text;
            String username = "";
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE  `User_Email` = @email and `User_Password` = @pass", db.getConnection());

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            


            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the user exists or not
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)   
                {
                    object[] arr = dr.ItemArray;
                    Program.CurrentUserID = Convert.ToInt32(arr[0]);
                    username = arr[1].ToString();
                    

                }
                Console.WriteLine("CurrentUser ID : "+Program.CurrentUserID);
                // Check if this user has a profile page or not then create one 
                Page.CreateProfilePage();
                Post.importPosts(Program.liOfPosts);
                Console.WriteLine("This User has this amount of posts : " + Program.liOfPosts.Count/7);
                Page.importUserPages(Program.liOfUserPages);
                Console.WriteLine("This User has this amount of pages : " + Program.liOfUserPages.Count/2);
                MessageBox.Show("Welcome to Andromeda "+username);
                this.Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("NO");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}