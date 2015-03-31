using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TwinternetDemo.RestAPI.Models
{
    [DataContract]
    class User : Model
    {
        [DataMember(Name = "ID")]
        public int ID;

        [DataMember(Name = "first_name")]
        public string FirstName;

        [DataMember(Name = "last_name")]
        public string LastName;

        [DataMember(Name = "avatar")]
        public string AvatarURL;

        public User() { }
    }
}
