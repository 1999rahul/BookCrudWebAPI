using System;

namespace BookCrud.Services.ViewModels;
public class BookVM
{

    public string BookName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
}

public class CreateBookVM : BookVM
{
    public CreateBookVM()
    {

    }
}

public class UpdateBookVM : BookVM
{
    public int Id { get; set; }

}

public class GetBookVM : BookVM
{
    public int Id { get; set; }

}