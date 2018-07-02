using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTunes_Search.Models
{

    public class Result
    {
        public string kind { get; set; }
        public int artistId { get; set; }
        public int trackId { get; set; }
        public string artistName { get; set; }
        public string trackName { get; set; }
        public string artistViewUrl { get; set; }
        public string trackViewUrl { get; set; }
        public string collectionName { get; set; }
        public string collectionViewUrl { get; set; }
        public int collectionId { get; set; }
    }
    

    public class ResultObject
    {
        public int resultCount { get; set; }
        public List<Result> results { get; set; }
    }
}