namespace Todo.Application.MappingProfile;

using AutoMapper;
using Todo.Application.Models;
using Todo.Domain.Entities;

public class Mappings: Profile
{
    public Mappings()
    {
        CreateMap<CreateTodoRequest, Todo>().ReverseMap();
        CreateMap<Todo, TodoDto>().ReverseMap();
    }
}
