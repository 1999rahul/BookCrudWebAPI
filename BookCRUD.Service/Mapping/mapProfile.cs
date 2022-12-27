using AutoMapper;
using BookCrud.Services.ViewModels;
using BookCRUD.Domain.Models;

namespace BookCRUD.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SpBook, GetBookVM>();
            CreateMap<GetBookVM, SpBook>();
            CreateMap<CreateBookVM, SpBook>();
            CreateMap<UpdateBookVM, SpBook>();
        }
    }
}