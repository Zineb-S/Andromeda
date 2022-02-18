using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;

namespace Andromeda
{
    public class User
    {   
       MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool UserStatus { get; set; }

        public User() {}

        public User(int ID , string username , string fname , string lname , string email , string password , string gender , DateTime birth, bool status)
        {
            this.UserID = ID;
            this.UserName = username;
            this.UserFirstName= fname;
            this.UserLastName= lname;
            this.Email = email; 
            this.Password = password;   
            this.DateOfBirth = birth;
            this.Gender = gender;
            this.UserStatus = status;
        }

        public static void importUsers(ArrayList usersList)
        
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);              
                

        }
        public static void exportUsers() { }

        public static void deleteUser() { }
        public static void updateUser() { }
        public static void ShowPosts() { }

    }
}
