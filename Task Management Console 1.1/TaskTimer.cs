using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Console_1._1
{
    class TaskTimer
    {
        private System.Threading.Timer timer;
        private List<User> users;
        private List<Task> tasks;

        public TaskTimer(List<User> users, List<Task> tasks)
        {
            this.users = users;
            this.tasks = tasks;
        }

        public void Start()
        {
            timer = new System.Threading.Timer(OnTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        public void Stop()
        {
            timer?.Dispose();
        }

        private void OnTimerTick(object state)
        {
            TaskManagement.ChangeTask(users, tasks);
            Output.informationBoard(users, tasks);
            TaskManagement.FreeTasks(users, tasks);

            if (TaskManagement.FinishedTask(users, tasks))
            {
                Output.TaskHistory(tasks);
                Console.WriteLine("All tasks were finished!");
                Stop();
            }
        }
    }
}
