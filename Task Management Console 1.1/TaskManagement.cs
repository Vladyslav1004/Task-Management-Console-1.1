using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Console_1._1
{
    class TaskManagement
    {
        static public void GetTasks(List<User> user, List<Task> task)
        {
            for (int i = 0; i < user.Count; i++)
            {
                for (int j = 0; j < task.Count; j++)
                {
                    if (user[i].isBusy == false && task[j].waiting == true)
                    {
                        task[j].assignedUser = user[i];
                        task[j].waiting = false;
                        task[j].inProgres = true;
                        user[i].isBusy = true;
                        task[j].usersHistory.Add(user[i]);
                    }
                }
            }
        }

        static public void ChangeTask(List<User> users, List<Task> tasks)
        {
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < tasks.Count; j++)
                {
                    if (!users[i].isBusy && tasks[j].waiting && users[i] != tasks[j].previousUser)
                    {
                        tasks[j].assignedUser = users[i];
                        tasks[j].waiting = false;
                        tasks[j].inProgres = true;
                        users[i].isBusy = true;
                        tasks[j].usersHistory.Add(users[i]);
                        break;
                    }
                }
            }
        }

        static public void FreeTasks(List<User> users, List<Task> tasks)
        {
            foreach (var task in  tasks)
            {
                foreach (var user in users)
                {
                    if (task.inProgres && task.assignedUser == user)
                    {
                        task.inProgres = false;
                        task.waiting = true;
                        task.previousUser = task.assignedUser;
                        task.assignedUser = null;
                        user.isBusy = false;
                    }
                }
            }
        }

        static public void FinishedTask(List<User> User, List<Task> Task)
        {
            bool isTaskFinished = false;
            foreach (var task in Task)
            {
                foreach (var user in User)
                {
                    if (task.usersHistory.Contains(user))
                    {
                        isTaskFinished = true;
                    }
                    else
                    {
                        isTaskFinished = false;
                    }
                }

                if (isTaskFinished) 
                {
                    task.finished = true;                
                }
            }
        }
    }
}
