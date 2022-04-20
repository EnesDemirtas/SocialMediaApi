using AutoMapper;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.MappingProfiles {

    internal class UserProfileMap : Profile {

        public UserProfileMap() {
            CreateMap<CreateUserCommand, BasicInfo>();
        }
    }
}