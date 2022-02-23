using System;
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
    public partial class AddEvent : Form
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string sdate = comboBox8.Text+'-'+ comboBox2.Text+'-'+ comboBox1.Text+' '+comboBox4.Text+':'+comboBox5.Text+":00";
            string edate = Box1.Text + '-' + Box2.Text + '-' + Box3.Text + ' ' + Box4.Text + ':' + Box5.Text + ":00";
            Event.exportEvents(title, sdate, edate);
            this.Hide();
            EventsList evlist = new EventsList();
            evlist.Show();
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {

        }
    }
}
