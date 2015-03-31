using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TwinternetDemo.RestAPI.Http;
using TwinternetDemo.RestAPI.Models;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace TwinternetDemo.RestAPI
{
    class JsonHandler
    {
        // Properties
        private string baseUrl;
        private bool setup = false;
        private HttpJson jsonType;
        private Object returnModel;
        private List<Post> returnList;
        private WebRequest webRequest;


        // Public constructor
        public JsonHandler() 
        {
        }


        // Public constructor with a string variable to setup the base url.
        public JsonHandler(string url, HttpJson type)
        {
            this.SetSettings(url, type);
        }


        // Method to set the settings for the handler
        public bool SetSettings(string url, HttpJson type)
        {
            if (url != null && !url.Equals(""))
            {
                this.baseUrl = url;
                this.setup = true;
                this.jsonType = type;
                return true;
            }

            return false;
        }


        // Setup equals false
        public bool IsSetup()
        {
            return this.setup;
        }


        // Get request for a list with objects.
        public async Task<bool> GetRequest<T>(string modelRequest)
        {
            if (!this.IsSetup())
                return false;

            Debug.WriteLine("JsonHandler:GetRequest - Everything is setup");

            try {
                webRequest = WebRequest.Create(this.baseUrl + jsonType.PostsUrl);
                Debug.WriteLine("JsonHandler:GetRequest - URL: " + this.baseUrl + jsonType.PostsUrl);
                WebResponse response = await webRequest.GetResponseAsync();

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
                this.returnList = (List<Post>) jsonSerializer.ReadObject(response.GetResponseStream());

                Debug.WriteLine("JsonHandler:GetRequest - Amount of items: " + returnList.Count);
                return true;
            }
            catch (WebException e)
            {
                Debug.WriteLine("JsonHandler:GetRequest - WebException:" + e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine("JsonHandler:GetRequest - Exception:" + e.Message);
            } 
            
            return false;
        }



        // Get request for a single object.
        public async Task<bool> GetRequestSingle(Model model, string modelRequest, int id)
        {
            if (!this.IsSetup())
                return false;

            Debug.WriteLine("JsonHandler:GetRequestSingle - Everything is setup");
            WordpressJson json = new WordpressJson();

            try
            {
                webRequest = WebRequest.Create(this.baseUrl + json.PostsUrl);
                Debug.WriteLine("JsonHandler:GetRequestSingle - URL: " + this.baseUrl + json.PostsUrl);
                WebResponse response = await webRequest.GetResponseAsync();
                Stream data = response.GetResponseStream();
                string output = String.Empty;

                using (StreamReader sr = new StreamReader(data))
                {
                    output = sr.ReadToEnd();
                }

                Debug.WriteLine("JsonHandler:GetRequestSingle - Output:" + output);
            }
            catch (WebException e)
            {
                Debug.WriteLine("JsonHandler:GetRequestSingle - WebException:" + e.Message);
            }


            if (id == -1)
                return false;
            return false;
        }


        // Gets the request list.
        public List<Post> GetObjectList()
        {
            return this.returnList;
        }


        // Creating a url.
        private string createUrl(string modelRequest)
        {
            return "";
        }



        /* 
         * HTTP POST REQUEST
         */

        //using (var client = new HttpClient())
        //{
        //    var values = new Dictionary<string, string>
        //    {
        //       { "thing1", "hello" },
        //       { "thing2", "world" }
        //    };

        //    var content = new FormUrlEncodedContent(values);

        //    var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        //    var responseString = await response.Content.ReadAsStringAsync();
        //}


        /* 
         * HTTP GET REQUEST
         */

        //WebRequest request = WebRequest.Create("http://www.google.com");
        //WebResponse response = request.GetResponse();
        //Stream data = response.GetResponseStream();
        //string html = String.Empty;
        //using (StreamReader sr = new StreamReader(data))
        //{
        //    html = sr.ReadToEnd();
        //}


    }
}
