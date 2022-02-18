using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void importEvents() { }
        public static void exportEvents() { }
        public static void deleteEvent() { }
        public static void updateEvent() { }
    }
}
