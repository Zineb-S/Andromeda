using Andromeda.Frames;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda
{
    internal class Event
    {
        /*
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Event() { }

        public Event(int ID , DateTime Sdate , DateTime Edate)
        {
            this.EventId = ID;
            this.StartDate = Sdate;
            this.EndDate = Edate;
        }
        */
        public static void importEvents( ArrayList liOfEvents) 
        {


            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `page` P INNER JOIN profile_page PI on PI.Page_ID=P.Page_ID WHERE Page_Type='Event' and User_ID='" + Program.CurrentUserID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

           
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    liOfEvents.Add(Convert.ToString(arr[i]));
                    
                }
            }
            
        }
        public static void exportEvents(string Title , string StartDate , string EndDate ) 
        {
            DateTime Date1= DateTime.Parse(StartDate);
            DateTime Date2 = DateTime.Parse(EndDate);
            if (Title.Equals("")|| StartDate.Equals("") || EndDate.Equals("") || Date2<Date1)
            {
                MessageBox.Show(" Please make sure to fill the whole form with proper dates as well!");

                AddEvent.ActiveForm.Dispose();
                AddEvent NewEvent = new AddEvent();
                NewEvent.Show();

            }
            else
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("INSERT INTO page(Page_Name,Page_Date,Page_Type ,Start_Date,End_Date) VALUES(@name, @date, @type,@startdate,@endDate)", db.getConnection());
                MySqlCommand command2 = new MySqlCommand("INSERT INTO profile_page(Page_ID,User_ID) VALUES(@pageID, @ID)", db.getConnection());
                DateTime now = DateTime.Now;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Title;
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = now;
                command.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Event";
                command.Parameters.Add("@startdate", MySqlDbType.DateTime).Value = StartDate;
                command.Parameters.Add("@endDate", MySqlDbType.DateTime).Value = EndDate;
                //open the connection
                db.openConnection();
                command.ExecuteNonQuery();
                Page.importPages(Program.liOfPages);
                int index = Convert.ToInt32(Program.liOfPages.Count) - 6;

                string PageID = Program.liOfPages[index].ToString();
              
                command2.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;
                command2.Parameters.Add("@pageID", MySqlDbType.Int32).Value = Int32.Parse(PageID);



                command2.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Event Added ");
            }


        }
        public static void deleteEvent(string ID)
        {

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM profile_page WHERE Page_ID='" + Convert.ToInt32(ID) + "' and User_ID='" + Program.CurrentUserID + "' ", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("DELETE FROM page WHERE Page_ID	='" + Convert.ToInt32(ID) + "'", db.getConnection());


            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show(" Event succefully Deleted ");
        }
        public static void updateEvent(string ID, string Title ,string StartDate , string EndDate)

        {
            DateTime Date1 = DateTime.Parse(StartDate);
            DateTime Date2 = DateTime.Parse(EndDate);
            if (Title.Equals("")|| StartDate.Equals("") || EndDate.Equals("")|| Date2<Date1 )
            {
                MessageBox.Show(" Please make sure to fill the whole form !");

                EditEvent.ActiveForm.Hide();
                EditEvent NewPost = new EditEvent(ID,Title,StartDate,EndDate);
                NewPost.Show();

            }
            else
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("UPDATE page SET Page_Name=@title, Start_Date=@sdate , End_Date=@edate WHERE Page_ID= '" + Convert.ToInt32(ID) + "'", db.getConnection());
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = Title;
                command.Parameters.Add("@sdate", MySqlDbType.DateTime).Value = StartDate;
                command.Parameters.Add("@edate", MySqlDbType.DateTime).Value = EndDate;
                //open the connection
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show(" Event succefully Edited ");
            }
        }
    }


    
}
