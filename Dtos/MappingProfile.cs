using AutoMapper;
using MovieRentalApp.Models;

namespace MovieRentalApp.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}