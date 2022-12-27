namespace BookCRUD.Domain.Models;
public class SpBook
{
    public int Id { get; set; }
    public string BookName { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
}