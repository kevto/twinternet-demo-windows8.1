using System;
using System.Collections.Generic;
using System.Text;

namespace TwinternetDemo.RestAPI.Http
{
    class WordpressJson : HttpJson
    {

        public override string ApiUrl
        { 
            get { return "/wp-json/"; }
        }

        public override string PostsUrl
        {
            get { return this.ApiUrl + "posts"; }
        }

        public override string PostUrl
        {
            get { return this.PostsUrl + "/?"; }
        }

        public override string CommentsUrl
        {
            get { return this.PostUrl + "/comments" ; }
        }

        public override string CommentUrl
        {
            get { return this.CommentsUrl + "/?"; }
        }
    }
}
