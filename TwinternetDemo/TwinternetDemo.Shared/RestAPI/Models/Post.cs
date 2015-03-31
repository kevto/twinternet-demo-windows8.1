using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TwinternetDemo.RestAPI.Models
{
    [DataContract]
    class Post : Model
    {
        [DataMember(Name = "ID")]
        public int ID;

        [DataMember(Name = "title")]
        public string Title;

        [DataMember(Name = "author")]
        public User Author;

        //[DataMember(Name = "category")]
        //public List<string> Categories;

        [DataMember(Name = "content")]
        public string Content;

        public Post() { }
    }
}
