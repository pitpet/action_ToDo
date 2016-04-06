using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public static List<ToDoElement> GetToDoList()
        public static ObservableCollection<ToDoElement> GetToDoList()
        {
            var ToDoList = new ObservableCollection<ToDoElement>();
            ToDoList.Add(new ToDoElement { Text = "Hallo" });
            ToDoList.Add(new ToDoElement { Text = "Hallo2" });
            return ToDoList;
        }

        public static ObservableCollection<ToDoElement> AddElementtoList(ObservableCollection<ToDoElement> ToDoElementList,string TextBoxText)
        {
            var ToDoList = ToDoElementList;
            ToDoList.Add(new ToDoElement { Text = TextBoxText });
            return ToDoList;
        }


        
        public static ObservableCollection<ToDoElement> DeleteElementfromList(ObservableCollection<ToDoElement> ToDoElementList, ToDoElement ActiveElement)
        {
            var ToDoList = ToDoElementList;
            ToDoList.Remove(ActiveElement);
            return ToDoList;
        }

    }

}
