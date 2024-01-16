using AutoMapper;
using BaltaIO.Api.ViewModel_DTO;
using BaltaIO.Business.Models;

namespace BaltaIO.Api.Configurantion
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<IBGE, IbgeViewModel>().ReverseMap();
        }
    }
}
