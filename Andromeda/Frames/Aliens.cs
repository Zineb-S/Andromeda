using Andromeda.Frames;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
            
            Program.here.Clear();
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT PP.Page_ID , P.Page_Type,PP.User_ID FROM profile_page PP INNER JOIN page P ON PP.Page_ID=P.Page_ID  WHERE User_ID = '" + IDLabel + "' and P.Page_Type = 'Profile'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    Program.here.Add(Convert.ToString(arr[i]));


                }
            }
            for (int i = 0;i < Program.here.Count;i+=3)
            {
                
                    Program.thatid = Convert.ToInt32(Program.here[i + 2]);
                    Program.thatProfileid = Convert.ToInt32((Program.here[i]));
                
                
                
            }
            Program.PreviousPage = "Corner";
            PostsList personalCorner = new PostsList();
            personalCorner.Show();

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
