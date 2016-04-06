using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using actionToDo.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace actionToDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private List<ToDoElement> ToDoElements;
        private ObservableCollection<ToDoElement> ToDoElements;
        private ObservableCollection<ToDoElement> ToDoElementList;
        public ToDoElement ActiveElement;

        public MainPage()
        {
            this.InitializeComponent();
            ToDoElements = ToDoElementManager.GetToDoList();
            ToDoElementList = ToDoElementManager.GetToDoList();
            ActiveElement = (new ToDoElement { Text = "zero" });
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "changed";

            //Sending a toast notification

            ToastTemplateType toastTemplate = ToastTemplateType.ToastText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            //Change content
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Hello World!"));

            //Create Toast
            ToastNotification toast = new ToastNotification(toastXml);

            //Send Toast
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }

        private void AddToDoButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoElementList = ToDoElementManager.AddElementtoList(ToDoElementList,ToDoTextBox.Text);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedElement = (ToDoElement)e.ClickedItem;
            ResultTextBlock.Text = clickedElement.Text;
            ActiveElement = clickedElement;
            
        }

        private void ActiveButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlockActive.Text = ActiveElement.Text;
        }

        private void DeleteToDoButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoElementList = ToDoElementManager.DeleteElementfromList(ToDoElementList,ActiveElement);
        }
    }
}
