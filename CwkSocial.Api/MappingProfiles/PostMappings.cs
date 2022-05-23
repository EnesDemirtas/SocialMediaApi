using AutoMapper;
using CwkSocial.Api.Contracts.Posts.Responses;
using CwkSocial.Domain.Aggregates.PostAggregate;

namespace CwkSocial.Api.MappingProfiles {

    public class PostMappings : Profile {

        public PostMappings() {
            CreateMap<Post, PostResponse>();
            CreateMap<PostComment, PostCommentResponse>();
            CreateMap<Domain.Aggregates.PostAggregate.PostInteraction, CwkSocial.Api.Contracts.Posts.Responses.PostInteraction>()
                .ForMember(dest =>
                dest.Type, opt =>
                opt.MapFrom(src =>
                src.InteractionType.ToString()))
                .ForMember(
                dest => dest.Author,
                opt => opt.MapFrom(
                    src => src.UserProfile));
        }
    }
}