using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda
{
    internal class Page
    {
        

        public int PageID { get; set; }
        public string PageName { get; set; }

        public DateTime PageDate { get; set; }
        public string PageType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }



        public Page() { }
        public Page(int ID, string name, DateTime date, string type, DateTime SDate, DateTime Etime) {
            this.PageID = ID;
            this.PageName = name;
            this.PageDate = date;
            this.PageType = type;
            this.StartDate = SDate;
            this.EndDate = Etime;
        }
        public static void importPages(ArrayList pagesList)
        {

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `page` ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    pagesList.Add(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);
        }
        public static void importUserPages(ArrayList userPagesList)
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `profile_page` WHERE User_ID	='" + Program.CurrentUserID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    userPagesList.Add(Convert.ToString(arr[i]));

                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);
        }

        public static void CreateProfilePage()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
            Console.WriteLine("here0");
            for (var i = 0; i < Program.liOfUserPages.Count; i+=2)
            {
                Console.WriteLine("here1");
                for (var j = 0; j < Program.liOfPages.Count; j++)
                {
                    Console.WriteLine("here2");
                    if (Program.liOfUserPages[i].ToString().Equals( Program.liOfPages[j].ToString()))
                    {
                        Console.WriteLine("here3");
                        if (Program.liOfPages[j+1].ToString().Equals("Profile"))
                        {
                            Console.WriteLine("User Has already a profile page ");
                            break;
                        }
                        else
                        {
                            //Create profile page
                            DB db = new DB();
                            MySqlCommand command = new MySqlCommand("INSERT INTO page(Page_Name,Page_Date,Page_Type ,Start_Date) VALUES(@name, @date, @type,@startdate)", db.getConnection());
                            MySqlCommand command2 = new MySqlCommand("INSERT INTO profile_page(Page_ID,User_ID) VALUES(@pageID, @ID)", db.getConnection());

                            DateTime now = DateTime.Now;
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Profile";
                            command.Parameters.Add("@date", MySqlDbType.Datetime).Value = now;
                            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Profile";
                            command.Parameters.Add("@startdate", MySqlDbType.Datetime).Value = now;




                            //open the connection
                            db.openConnection();


                            command.ExecuteNonQuery();
                            Console.WriteLine("Profile page created ");



                            //close connection
                           
                            importPages(Program.liOfPages);
                            int PageID = (int)Program.liOfPages[Program.liOfPages.Count - 10];
                            command2.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;
                            command2.Parameters.Add("@pageID", MySqlDbType.Datetime).Value = PageID;
                            db.openConnection();


                            command2.ExecuteNonQuery();
                            Console.WriteLine("info profile page added ");



                            //close connection
                            db.closeConnection();





                            break;

                        }
                    }
                }
            }
        } 

        public static void exportPages() { }
        public static void deletePage() { }
        public static void updatePage() { }

    }
}
