using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TwinternetDemo.RestAPI;
using TwinternetDemo.RestAPI.Http;
using TwinternetDemo.RestAPI.Models;
using TwinternetDemo.RestAPI.PropertyChanged;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwinternetDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<PropPost> CollectionPosts
        {
            get;
            set;
        }

        public MainPage()
        {
            CollectionPosts = new ObservableCollection<PropPost>();
            this.InitializeComponent();    
        }

        private async void TestEvent_Click(object sender, RoutedEventArgs e)
        {
            JsonHandler handler = new JsonHandler();
            handler.SetSettings("http://www.twinternet.nl", new WordpressJson());

            if (await handler.GetRequest<Post>("posts"))
            {
                if (CollectionPosts.Count != 0)
                    CollectionPosts.Clear();

                Debug.WriteLine("MainPage:TestEvent_Click - Count Object List: " + handler.GetObjectList().Count);

                foreach (Post post in handler.GetObjectList())
                    CollectionPosts.Add(new PropPost(post.Title, post.Author.FirstName + " " + post.Author.LastName));


                Debug.WriteLine("MainPage:TestEvent_Click - Count Collection: " + CollectionPosts.Count);
            }
        }

        // Insert new onload method for gridview postsgridview
    }
}
