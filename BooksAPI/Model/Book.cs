using Newtonsoft.Json;
using System;

namespace BooksAPI.Model
{
    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
