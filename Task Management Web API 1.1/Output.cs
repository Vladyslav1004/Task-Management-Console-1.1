using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Web_API_1._1
{
    class Output
    {
        static public void informationBoard(List<User> users, List<Task> tasks)
        {
            foreach (var user in users)
            {
                var busyTask = tasks.FirstOrDefault(t => t.assignedUser == user);
                if (busyTask != null)
                {
                    Console.WriteLine($"User: {user.name} {user.lastName}, his task {busyTask.taskName} ");
                }
                else
                {
                    Console.WriteLine($"User: {user.name} {user.lastName}, his has no tasks ");
                }

            }

            Console.WriteLine($"Free Tasks:");
            foreach (var task in tasks)
            {
                if (task.notStarted == true)
                {
                    Console.WriteLine(task.taskName);
                }
            }
        }
    }
}
