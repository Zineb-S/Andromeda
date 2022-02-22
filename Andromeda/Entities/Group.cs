﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda
{
    internal class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public DateTime GroupDate { get; set; }

        public Group() { }
        public Group(int ID , string name, DateTime date)
        {
            this.GroupId=ID;
            this.GroupName=name;
            this.GroupDate=date;
        }
        public static void importGroups() { }
        public static void exportGroups(string Title) 
        {

            if (Title.Equals(""))
            {
                MessageBox.Show(" Please make sure to fill the whole form !");

                AddPage.ActiveForm.Hide();
                AddPage NewPage = new AddPage();
                NewPage.Show();

            }
            else
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("INSERT INTO page(Page_Name,Page_Date,Page_Type ,Start_Date) VALUES(@name, @date, @type,@startdate)", db.getConnection());
                MySqlCommand command2 = new MySqlCommand("INSERT INTO profile_page(Page_ID,User_ID) VALUES(@pageID, @ID)", db.getConnection());
                DateTime now = DateTime.Now;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Title;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = now;
                command.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Group";
                command.Parameters.Add("@startdate", MySqlDbType.DateTime).Value = now;
                //open the connection
                db.openConnection();
                command.ExecuteNonQuery();
                Page.importPages(Program.liOfPages);
                int index = Convert.ToInt32(Program.liOfPages.Count) - 6;

                string PageID = Program.liOfPages[index].ToString();
                Console.WriteLine(PageID);
                command2.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;
                command2.Parameters.Add("@pageID", MySqlDbType.Int32).Value = Int32.Parse(PageID);



                command2.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Group Added ");
            }

            
        }
        public static void deleteGroup() { }
        public static void updateGroup() { }
    }
}
