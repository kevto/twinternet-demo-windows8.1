﻿using System;
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
    public sealed partial class MainPage : Page
    {

        public PostCollection postCollectionModelView;

        public MainPage()
        {
            postCollectionModelView = new PostCollection();
            postCollectionModelView.Items = new ObservableCollection<PropPost>();
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }


        // Method that executes once the mainpage has been completely loaded successfully.
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetPosts();
        }


        // TestEvent click to test the click events of a button.
        private void TestEvent_Click(object sender, RoutedEventArgs e)
        {
            GetPosts();
        }


        // Gets all the posts of a Wordpress website, ours in this case and
        // places them all in the ObservableCollection
        async void GetPosts()
        {
            JsonHandler handler = new JsonHandler();
            handler.SetSettings("http://www.twinternet.nl", new WordpressJson());

            if (await handler.GetRequest<Post>("posts"))
            {
                if (postCollectionModelView.Items.Count != 0)
                    postCollectionModelView.Items.Clear();

                Debug.WriteLine("MainPage:TestEvent_Click - Count Object List: " + handler.GetObjectList().Count);

                foreach (Post post in handler.GetObjectList())
                    postCollectionModelView.Items.Add(new PropPost(post.Title, post.Author.FirstName + " " + post.Author.LastName));


                Debug.WriteLine("MainPage:TestEvent_Click - Count Collection: " + postCollectionModelView.Items.Count);
            }
        }
    }
}
