using AutoMapper;
using CwkSocial.Api.Contracts.Identity;
using CwkSocial.Application.Identity.Commands;
using CwkSocial.Application.Identity.Dtos;

namespace CwkSocial.Api.MappingProfiles {

    public class IdentityMappings : Profile {

        public IdentityMappings() {
            CreateMap<UserRegistration, RegisterIdentity>();
            CreateMap<Login, LoginCommand>();
            CreateMap<IdentityUserProfileDto, IdentityUserProfile>();
        }
    }
}