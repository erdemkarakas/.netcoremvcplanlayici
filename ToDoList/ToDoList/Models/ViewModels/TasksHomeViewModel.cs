using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models.ViewModels
{
    public class TasksHomeViewModel
    {
        public TasksHomeViewModel()
        {
            today = DateTime.Now;
        }

        public Gorev task { get; set; }
        public DateTime today { get; set; }


    }
}
