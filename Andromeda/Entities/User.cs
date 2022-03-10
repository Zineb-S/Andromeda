        using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;

namespace Andromeda
{
    public class User
    {   
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
        /*public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool UserStatus { get; set; }

        public User() { }

        public User(int ID, string username, string fname, string lname, string email, string password, string gender, DateTime birth, bool status)
        {
            this.UserID = ID;
            this.UserName = username;
            this.UserFirstName = fname;
            this.UserLastName = lname;
            this.Email = email;
            this.Password = password;
            this.DateOfBirth = birth;
            this.Gender = gender;
            this.UserStatus = status;
        }
        */

        //USERS
        public static void importUsers(ArrayList usersList)

        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    usersList.Add(Convert.ToString(arr[i]));
            
                }
            }
            


        }
        public static void exportUsers(string fname, string lname, string username, string email, string pass, string confirm, string year, string month, string day, string date, string gender)
        {
            //add new user
            DB db = new DB();

            bool checkTextBoxesValues()
            {
                if (fname.Equals("") || lname.Equals("") || username.Equals("") || email.Equals("") || pass.Equals("") || confirm.Equals("") || year.Equals("") || month.Equals("") || day.Equals("")|| date.Equals("") ||gender.Equals(""))
                {
                    MessageBox.Show(" Please make sure to fill the whole form !");
                    return true;
                }

                for (var i = 0; i < Program.liOfUsers.Count; i++)
                {
                    if (Program.liOfUsers[i].ToString().Equals(username))
                    {
                        MessageBox.Show(" User Name already exists ! Please Change it ");
                        return true;
                    }

                    if (Program.liOfUsers[i].ToString().Equals(email))
                    {
                        MessageBox.Show(" Email already exists ! Please Change it ");
                        return true;    
                    }
                }
                

                   
                if (pass != confirm)
                {
                    MessageBox.Show("Your Passwords doesn't match :( ");
                    return true;
                }
                if ((Int32.Parse(year) > 2022) || (Int32.Parse(day) > 31) || (Int32.Parse(month) > 12))
                {
                    MessageBox.Show("There seems to be problem with the Date please choose a proper one");
                    return true;
                }
                else
                {
                    return false;
                }

            }

            MySqlCommand command = new MySqlCommand("INSERT INTO users(User_Name, User_First_Name, User_Last_Name, User_Email, User_Password, Date_Of_Birth, Gender_Users) VALUES(@usn, @fn, @ln, @email, @pass,@year, @gender)", db.getConnection());
            
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = date;
            command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;


            //open the connection
            db.openConnection();

            if (checkTextBoxesValues())
            {
                RegisterForm.ActiveForm.Hide();
                RegisterForm rf = new RegisterForm();
                rf.Show();
            }
            else
            {
                
                command.ExecuteNonQuery();
                importUsers(Program.liOfUsers);
                MessageBox.Show("Account Created ! Now you have to login  ");
                RegisterForm.ActiveForm.Hide();
                LoginForm lf = new LoginForm();
                lf.Show();
                

            }

            


            //close connection
            db.closeConnection();
        }
        public static void DeleteUser() 
        {

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM users WHERE User_ID='" + Program.CurrentUserID + "'", db.getConnection());


            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Your Account has been deleted !! BYE ");

        }
        public static void UpdateUser( string Username , string email , string password , string cpassword) 
        {
            
            DB db = new DB();
            bool checkTextBoxesValues()
            {
                if (Username.Equals("") || email.Equals("") || password.Equals("") || password!=cpassword)
                {
                    MessageBox.Show(" Please make sure to fill the whole form !");
                    return true;
                }

                for (var i = 0; i < Program.liOfUsers.Count; i++)
                {
                    if (Program.liOfUsers[i].ToString().Equals(Username))
                    {
                        MessageBox.Show(" User Name already exists ! Please Change it ");
                        return true;
                    }

                    if (Program.liOfUsers[i].ToString().Equals(email))
                    {
                        MessageBox.Show(" Email already exists ! Please Change it ");
                        return true;
                    }
                }
                return false;
            }
            MySqlCommand command = new MySqlCommand("UPDATE users SET User_Name='"+ Username + "' , User_Email='"+email+"', User_Password='"+password+"' WHERE User_ID="+Program.CurrentUserID+"", db.getConnection());

          
          

            if (checkTextBoxesValues())
            {
                Settings.ActiveForm.Hide();
                Settings rf = new Settings(Username,email,password);
                rf.Show();
            }
            else
            {
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                importUsers(Program.liOfUsers);
                Program.CurrentUserUsername=Username;
                Program.CurrentUserEmail = email;
                Program.CurrentUserPassword = password;
                   
                MessageBox.Show("Your Informations have been updated !");
                Profile profile = new Profile();
                profile.Show();


            }










            
        }
        
        //MEMBERS
        public static void importNONmembers(ArrayList nonmembers)


        {
            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            switch (Program.PreviousPage)
            {
                case "Group":

                    MySqlCommand command = new MySqlCommand("SELECT us.User_ID, us.User_Name FROM users us WHERE us.User_ID not in (SELECT User_ID from group_members gm WHERE gm.Page_ID = '" + Program.PreviousPageID + "')", db.getConnection());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);


                    foreach (DataRow dr in table.Rows)
                    {
                        object[] arr = dr.ItemArray;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            nonmembers.Add(Convert.ToString(arr[i]));

                        }
                    }


                    break;
                case "Event":

                    MySqlCommand command2 = new MySqlCommand("SELECT us.User_ID, us.User_Name FROM users us WHERE us.User_ID not in (SELECT User_ID from event_members gm WHERE gm.Page_ID = '" + Program.PreviousPageID + "')", db.getConnection());

                    adapter.SelectCommand = command2;
                    adapter.Fill(table);


                    foreach (DataRow dr in table.Rows)
                    {
                        object[] arr = dr.ItemArray;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            nonmembers.Add(Convert.ToString(arr[i]));

                        }
                    }


                    break;
            }





        }
        public static void ImportGroupMembers(ArrayList GroupMembers)

        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT gm.Page_ID, gm.User_ID, us.User_Name , gm.Group_Member_Role FROM `group_members` gm INNER JOIN users us on gm.User_ID = us.User_ID WHERE Page_ID ='" + Program.PreviousPageID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    GroupMembers.Add(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);
        }
        public static void ImportEventMembers(ArrayList EventMembers)

        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT gm.Page_ID, gm.User_ID, us.User_Name , gm.Event_Member_Role FROM `event_members` gm INNER JOIN users us on gm.User_ID = us.User_ID WHERE Page_ID ='" + Program.PreviousPageID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    EventMembers.Add(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);

        }
        public static void ExportMembers(string UserID , string Role) 
        
        {
            if (Role == "")
            {
                MessageBox.Show("Make sure to give a role to this user ");
            }
            else
            {
                DB db = new DB();
                switch (Program.PreviousPage)
                {
                    case "Event":
                        MySqlCommand command = new MySqlCommand("INSERT INTO `event_members` (`Page_ID`, `User_ID`, `Event_Member_Role`) VALUES(@pgID, @usrID, @role)", db.getConnection());

                        command.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.PreviousPageID;
                        command.Parameters.Add("@usrID", MySqlDbType.Int32).Value = Convert.ToInt32(UserID);
                        command.Parameters.Add("@role", MySqlDbType.VarChar).Value = Role;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        break;


                    case "Group":

                        
                        MySqlCommand command2 = new MySqlCommand("INSERT INTO `group_members` (`Page_ID`, `User_ID`, `Group_Member_Role`) VALUES(@pgID, @usrID, @role)", db.getConnection());

                        command2.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.PreviousPageID;
                        command2.Parameters.Add("@usrID", MySqlDbType.Int32).Value = Convert.ToInt32(UserID);
                        command2.Parameters.Add("@role", MySqlDbType.VarChar).Value = Role;

                        db.openConnection();
                        command2.ExecuteNonQuery();
                        db.closeConnection();
                        break;


                }

            }


        }
        public static void DeleteMember(string ID)
        {
            DB db = new DB();
            switch (Program.PreviousPage)

            {
                case "Group":
                   

                    MySqlCommand command = new MySqlCommand("DELETE FROM group_members WHERE User_ID='" + ID + "'", db.getConnection());


                    //open the connection
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    MessageBox.Show("Member is Removed From Group ");
                    break;
                case "Event":
               
                    MySqlCommand command2 = new MySqlCommand("DELETE FROM event_members WHERE User_ID='" + ID + "'", db.getConnection());
                    //open the connection
                    db.openConnection();
                    command2.ExecuteNonQuery();
                    db.closeConnection();
                    MessageBox.Show("Member is Removed From Event ");
                    break;
            }
            
        }

       
        
    }
}
