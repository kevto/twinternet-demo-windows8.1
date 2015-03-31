using System;
using System.Collections.Generic;
using System.Text;

namespace TwinternetDemo.RestAPI.Http
{
    abstract class HttpJson : IHttpJson
    {

        abstract public string ApiUrl { get; }

        abstract public string PostsUrl { get; }

        abstract public string PostUrl { get; }
        
        abstract public string CommentsUrl { get; }

        abstract public string CommentUrl { get; }
    }
}
