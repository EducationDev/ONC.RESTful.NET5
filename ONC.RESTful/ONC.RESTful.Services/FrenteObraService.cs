using AutoMapper;
using Microsoft.Extensions.Options;
using ONC.RESTful.API.Common.Settings;
using ONC.RESTful.Services.Contracts;
using ONC.RESTful.Services.Model;
using System;
using System.Threading.Tasks;
using ONC.RESTful.Data.Obra;

namespace ONC.RESTful.Services
{
    public class FrenteObraService : IFrenteObraService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public FrenteObraService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public Task<bool> UpdateAsync(FrenteObraEstadoNumero model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<FrenteObraEstadoNumero> GetAsync(int estado, string numero)
        {
            var result = default(FrenteObraEstadoNumero);

            // Declaracion del componente de acceso a datos.
            var dac = new FrenteObraDac();

            // llamar a SelectByEstadoAndNumero en FrenteObraDac.
            result = await dac.SelectByEstadoAndNumero(estado, numero);
            return result;
            
        }
    }
}
