using System;

namespace ONC.RESTful.API.DataContracts.Requests
{
    public class FrenteObraCreationRequest
    {
        public DateTime Date { get; set; }

        public FrenteObraEstadoNumero FrenteObra { get; set; }
    }
}
