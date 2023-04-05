namespace BookPublisher.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Email  { get; set; }
    
        public DateTime DataNascimento { get; set;}

        public IList<BookAuthor> BookAuthors { get; set;} = new List<BookAuthor>(); 
    }

}
