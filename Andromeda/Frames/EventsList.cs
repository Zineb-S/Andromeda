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
    public partial class EventsList : Form
    {
        public EventsList()
        {
            Program.PreviousPage = "Event";
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            Program.liOfEvents.Clear();
            Event.importEvents(Program.liOfEvents);
            for (int i = 0; i < Program.liOfEvents.Count; i += 8)
            {
                flowLayoutPanel1.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfEvents[i]), Program.liOfEvents[i + 1].ToString(), Program.liOfEvents[i + 2].ToString(), Program.liOfEvents[i + 3].ToString(), Program.liOfEvents[i + 4].ToString(), Program.liOfEvents[i + 5].ToString()));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEvent NEvent = new AddEvent();
            NEvent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void EventsList_Load(object sender, EventArgs e)
        {

        }
    }
}
