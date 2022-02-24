using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda.Frames
{
    public partial class EditEvent : Form
    {
        public string I = "";
        public string T = "";
        public string S = "";
        public string E = "";

        public EditEvent(string ID , string Title , string sdate , string edate)
        {
            I = ID;
            T = Title;
            S = sdate;
            E = edate;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            T= textBox1.Text;
            S = comboBox8.Text + "-" + comboBox2.Text + "-" + comboBox1.Text + " " + comboBox4.Text + ":" + comboBox5.Text + ":00";
            E= comboBox7.Text + "-" + textBoxBirthMonth.Text + "-" + textBoxBirthDay.Text + " " + comboBox3.Text + ":" + comboBox6.Text + ":00";
            Event.updateEvent(I,T,S,E);
            EventsList eventsList = new EventsList();
            eventsList.Show();
        }

        private void EditEvent_Load(object sender, EventArgs e)
        {

        }
    }
}
