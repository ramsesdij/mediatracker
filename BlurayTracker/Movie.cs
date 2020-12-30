using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurayTracker
{
    public class MovieJson
    {
        [JsonProperty("movies")]
        public List<Movie> movies { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public string Format { get; set; }
        public bool Available { get; set; }

        public Movie(string Title, string Year, string Country, string Format, bool Available)
        {
            this.Title = Title;
            this.Year = Year;
            this.Country = Country;
            this.Format = Format;
            this.Available = Available;
        }
    }
}
