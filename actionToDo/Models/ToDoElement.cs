using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actionToDo.Models
{
    public class ToDoElement
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string status { get; set; }
        public int ID { get; set; }

    }


    public class ToDoElementManager
    {
        public static List<ToDoElement> GetToDoList()
        {
            var ToDoList = new List<ToDoElement>();
            ToDoList.Add(new ToDoElement { Text = "Hallo" });
            ToDoList.Add(new ToDoElement { Text = "Hallo2" });
            return ToDoList;

        }


    }

}
