using AutoMapper;
using CwkSocial.Api.Contracts.Identity;
using CwkSocial.Application.Identity.Commands;

namespace CwkSocial.Api.MappingProfiles {

    public class IdentityMappings : Profile {

        public IdentityMappings() {
            CreateMap<UserRegistration, RegisterIdentity>();
        }
    }
}