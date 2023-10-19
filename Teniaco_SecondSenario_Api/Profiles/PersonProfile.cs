using AutoMapper;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;
using Teniaco_SecondSenario_Api.Models.Entities.Person;
using System.Collections.Generic; // Add this namespace if not already added.

namespace Teniaco_SecondSenario_Api.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
