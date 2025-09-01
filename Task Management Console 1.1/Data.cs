using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Console_1._1
{
    class Data
    {
        private static List<Task> tasks = new List<Task>()
        {
            new Task {taskName = "Calculating",waiting = true, inProgres = false, finished = false},
            new Task {taskName = "Programing",waiting = true},
            new Task {taskName = "Reading", waiting = true},
            new Task {taskName = "Teaching", waiting= true},
            new Task {taskName = "Building", waiting = true}
        };

        public static List<Task> Tasks
        {
            get { return tasks; }
        }

        private static List<User> users = new List<User>()
        {
            new User {name = "Vlad", lastName = "Semizorov", isBusy = false},
            new User {name = "Dima", lastName = "Bondarenko", isBusy = false},
            new User {name = "Vova", lastName = "Sem", isBusy = false},
        };

        public static List<User> Users
        {
            get { return users; }
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
