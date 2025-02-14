using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateProductRequest, CreateUserCommand>();
        CreateMap<CreateProductRequest, User>();
        CreateMap<User, CreateProductRequest>();
        CreateMap<CreateProductResponse, User>();
        CreateMap<User, CreateProductResponse>();
    }
}