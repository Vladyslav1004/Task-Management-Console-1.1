using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Web_API_1._1
{
    class Task
    {
        public string taskName;
        public bool notStarted;
        public bool inProgres;
        public bool finished;

        public User assignedUser { get; set; }
    }
}
