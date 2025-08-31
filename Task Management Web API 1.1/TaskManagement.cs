using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Web_API_1._1
{
    class TaskManagement
    {
        static public void GetTasks(List<User> users, List<Task> tasks)
        {
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < tasks.Count; j++)
                {
                    if (users[i].isBusy == false && tasks[j].notStarted == true)
                    {
                        Task freeTask = null;
                        freeTask = tasks[j];
                        freeTask.assignedUser = users[i];
                        freeTask.notStarted = false;
                        freeTask.inProgres = true;
                        users[i].isBusy = true;
                    }
                }
            }
        }
    }
}
