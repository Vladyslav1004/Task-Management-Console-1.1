using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Console_1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = Data.Users;
            List<Task> tasks = Data.Tasks;


            while (true)
            {
                Console.WriteLine($"You have {users.Count} users. Do you want to add more?");
                string str = Console.ReadLine();

                if (str == "y" || str == "Y")
                {
                    User newUser = new User();
                    Console.Write("Enter his/her name: ");
                    newUser.name = Console.ReadLine();
                    Console.Write("Enter his/her last name: ");
                    newUser.lastName = Console.ReadLine();

                    Data.AddUser(newUser);

                    Console.Write("If you finished, enter y/Y: ");
                    str = Console.ReadLine();
                    if (str == "y" || str == "Y")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    break;
                }
            }


            TaskManagement.GetTasks(users, tasks);
            Output.informationBoard(users, tasks);
            Output.TaskHistory(tasks);
            TaskManagement.FreeTasks(users, tasks);
            while (true)
            {
                TaskManagement.ChangeTask(users, tasks);
                Output.informationBoard(users, tasks);
                Output.TaskHistory(tasks);

                TaskManagement.FreeTasks(users, tasks);   // ← спочатку звільняємо

                if (TaskManagement.FinishedTask(users, tasks))  // ← тепер перевіряємо
                {
                    Console.WriteLine("All tasks were finished");
                    break;
                }
            }
        }
    }
}
