using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetUserRequestProfile : Profile
{
    public GetUserRequestProfile()
    {
        CreateMap<GetUserRequest, GetUserCommand>();
        CreateMap<GetUserRequest, User>();
        CreateMap<User, GetUserRequest>();
        CreateMap<GetUserResponse, User>();
        CreateMap<User, GetUserResponse>();      
    }
}