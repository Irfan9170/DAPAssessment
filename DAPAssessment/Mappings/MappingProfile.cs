using AutoMapper;
using DAPAssessment.Models;
using DAPAssessment.Models.Dto;

namespace DAPAssessment.Mappings
{
 

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }

}
