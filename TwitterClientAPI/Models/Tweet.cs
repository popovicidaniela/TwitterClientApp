using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClientAPI.Models
{
    public class Tweet
    {
        public string text { get; set; }
        public string created_at { get; set; }
    }
}