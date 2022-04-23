using AutoMapper;
using CwkSocial.Api.Contracts.Posts.Responses;
using CwkSocial.Domain.Aggregates.PostAggregate;

namespace CwkSocial.Api.MappingProfiles {

    public class PostMappings : Profile {

        public PostMappings() {
            CreateMap<Post, PostResponse>();
        }
    }
}