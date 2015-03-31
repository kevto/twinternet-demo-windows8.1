using System;
using System.Collections.Generic;
using System.Text;

namespace TwinternetDemo.RestAPI.Http
{
    interface IHttpJson
    {
        string ApiUrl { get; }
        string PostsUrl { get; }
        string PostUrl { get; }
        string CommentsUrl { get; }
        string CommentUrl { get; }
    }
}
