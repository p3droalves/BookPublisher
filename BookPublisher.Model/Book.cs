namespace BookPublisher.Model
{
    public class Book
    {

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int IBSN { get; set; }
        public int Ano { get; set; }

        public IList<BookAuthor> bookAuthors  { get; set;} = new List<BookAuthor>();    

    }
}
