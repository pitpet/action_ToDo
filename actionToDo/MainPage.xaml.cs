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
//using NotificationsExtensions.Toasts;
using System.Xml.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace actionToDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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

        public static XmlDocument CreateToast()
        {
            var xDoc = new XDocument(
                new XElement("toast",
                    new XElement("visual",
                        new XElement("binding", new XAttribute("template", "ToastGeneric"),
                            new XElement("text", "C# Corner"),
                            new XElement("text", "Did you got MVP award?")
                            )
                        ),// actions  
                    new XElement("actions",
                        new XElement("action", new XAttribute("activationType", "background"),
                            new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
                        new XElement("action", new XAttribute("activationType", "background"),
                            new XAttribute("content", "No"), new XAttribute("arguments", "no"))
                        )
                    )
                );

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }
        private void showToastBtn_Click(object sender, RoutedEventArgs e)
        {
            var xmdock = CreateToast();
            var toast = new ToastNotification(xmdock);
            var notifi = ToastNotificationManager.CreateToastNotifier();
            notifi.Show(toast);

        }
    }


}

