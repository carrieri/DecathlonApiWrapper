using System.Collections.Generic;

namespace DecathlonApiWrapper.Models
{
    public class PagedData<T> where T : class
    {
        public List<T> Results { get; set; } 
        public string NextPage { get; set; }
    }
}
