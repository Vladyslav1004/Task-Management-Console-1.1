using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Console_1._1
{
    class Task
    {
        public string taskName;
        public bool waiting;
        public bool inProgres;
        public bool finished;

        public User assignedUser { get; set; }
        public User previousUser { get; set; }

        public List<User> usersHistory { get; set; } = new List<User>();
    }
}
