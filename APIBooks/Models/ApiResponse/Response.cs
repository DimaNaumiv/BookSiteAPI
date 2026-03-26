namespace APIBooks.Models.ApiResponse
{
    public class ApiResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Book> results { get; set; }
        public Dictionary<string, string> formats { get; set; }
    }
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public Dictionary<string, string> formats { get; set; }
        public List<Author> authors { get; set; }
        public List<string> languages { get; set; }
    }
    public class Author
    {
        public string name { get; set; }
        public int? birth_year { get; set; }
        public int? death_year { get; set; }
    }
}
