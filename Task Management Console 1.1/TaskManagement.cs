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

        static public void ChangeTask(List<User> User, List<Task> Task)
        {
            Random rand = new Random();
            foreach (var user in User)
            {
                if (!user.isBusy)
                {
                    var availableTask = Task.Where(t => t.waiting && t.previousUser != user && !t.finished).ToList();

                    if (availableTask.Count > 0)
                    {
                        var task = availableTask[rand.Next(availableTask.Count)];
                        task.assignedUser = user;
                        task.waiting = false;
                        task.inProgres = true;
                        user.isBusy = true;
                        task.usersHistory.Add(user);
                    }
                }
            }
        }

        static public void FreeTasks(List<User> users, List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                foreach (var user in users)
                {
                    if (task.inProgres && task.assignedUser == user)
                    {
                        task.inProgres = false;

                        if (!task.finished)   // ← перевірка
                        {
                            task.waiting = true;
                        }
                        else
                        {
                            task.waiting = false;
                        }

                        task.previousUser = task.assignedUser;
                        task.assignedUser = null;
                        user.isBusy = false;
                    }
                }
            }
        }

        static public bool FinishedTask(List<User> users, List<Task> tasks)
        {
            bool allFinished = true;

            foreach (var task in tasks)
            {
                if (task.finished)
                    continue;

                bool isTaskFinished = users.All(u => task.usersHistory.Contains(u));

                if (isTaskFinished)
                {
                    task.finished = true;
                    task.waiting = false;
                    task.inProgres = false;
                }
                else
                {
                    allFinished = false;
                }
            }

            return allFinished;
        }
    }
}
