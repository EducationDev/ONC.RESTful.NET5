using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ONC.RESTful.API.DataContracts;
using ONC.RESTful.Services.Contracts;
using System;
using System.Threading.Tasks;
using ONC.RESTful.API.Common.Attributes;
using S = ONC.RESTful.Services.Model;

namespace ONC.RESTful.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/frenteobra")]//required for default versioning
    //[Route("api/v{version:apiVersion}/frenteobra")]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    [ApiController]
    public class FrenteObraController : Controller
    {
        private readonly IFrenteObraService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<FrenteObraController> _logger;

#pragma warning disable CS1591
        public FrenteObraController(IFrenteObraService service, IMapper mapper, ILogger<FrenteObraController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }
#pragma warning restore CS1591

        #region GET
        /// <summary>
        /// Este método se encarga de retornar un objeto Frente de Obra, tomando como datos de filtros el estado y el número de Frente de Obra..
        /// </summary>
        /// <remarks>
        /// Los comentarios XML incluidos en los controladores se extraerán e inyectarán en el archivo Swagger / OpenAPI.
        /// </remarks>
        /// <param name="estado"> Valor numérico que representa el Estado del Frente de Obra.</param>
        /// <param name="numero"> Valor alfanumérico que representa el Número del Frente de Obra.</param>
        /// <returns>
        /// Devuelve la entidad FrenteObraEstadoNumero de acuerdo con el estado y numero proporcionado.
        /// </returns>
        /// <response code="200">FrenteObra</response>
        /// <response code="204">If the item is null.</response>
        /// <response code="400">Bad request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FrenteObraEstadoNumero))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(FrenteObraEstadoNumero))]
        //[HttpGet("{estado}/{numero}")]
        [HttpGet]
        public async Task<FrenteObraEstadoNumero> Get(int estado, string numero)
        {
            _logger.LogDebug($"FrenteObraController::Get::{estado} {numero}");

            var data = await _service.GetAsync(estado, numero);

            if (data != null)
                return _mapper.Map<FrenteObraEstadoNumero>(data);
            else
                return null;
        }
        #endregion

        #region Exceptions
        [HttpGet("exception/{message}")]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task RaiseException(string message)
        {
            _logger.LogDebug($"UserControllers::RaiseException::{message}");
            throw new Exception(message);

        }
        #endregion
    }
}
