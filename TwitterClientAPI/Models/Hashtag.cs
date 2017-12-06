using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClientAPI.Models
{
    public class Hashtag
    {
        public List<Tweet> statuses { get; set; }
        public HashtagMetadata search_metadata { get; set; }
    }
}