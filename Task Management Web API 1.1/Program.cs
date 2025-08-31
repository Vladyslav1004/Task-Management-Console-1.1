using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Web_API_1._1
{
    

    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = Data.Users;
            List<Task> tasks = Data.Tasks;

            TaskManagement.GetTasks(users, tasks);
            Output.informationBoard (users, tasks);
        }
    }
}
