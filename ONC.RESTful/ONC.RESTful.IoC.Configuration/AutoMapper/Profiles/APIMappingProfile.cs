using AutoMapper;
using DC = ONC.RESTful.API.DataContracts;
using S = ONC.RESTful.Services.Model;

namespace ONC.RESTful.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.FrenteObraEstadoNumero, S.FrenteObraEstadoNumero>().ReverseMap();
        }
    }
}
