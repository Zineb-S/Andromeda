using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda
{
    internal class Event
    {
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
        public static void importEvents() { }
        public static void exportEvents() { }
        public static void deleteEvent() { }
        public static void updateEvent() { }
    }


    
}
