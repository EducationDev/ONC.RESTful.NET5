using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Oracle;
using ONC.RESTful.Services.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace ONC.RESTful.Data.Obra
{
    public class FrenteObraDac : DataAccessComponent
    {
        /// <summary>
        /// COMPRAS_NACION.OBRA.FrenteObra.EstadoFrenteObra = 3  AND NumeroFrenteObra = '81-0001-FDO18'
        /// </summary>
        /// <param name="estado"> Valor numérico que representa el Estado del Frente de Obra.</param>
        /// <param name="numero"> Valor alfanumérico que representa el Número del Frente de Obra.</param>
        /// <returns>Devuelve un objeto FrenteObraGetEstadoNumero.</returns>
        public async Task<FrenteObraEstadoNumero> SelectByEstadoAndNumero(int estado, string numero)
        {
            return await Task.FromResult(ParseFrenteObraGetEstadoNumero());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private FrenteObraEstadoNumero ParseFrenteObraGetEstadoNumero(IDataReader dr)
        {
            // Leer valores.
            var result = new FrenteObraEstadoNumero
            {
                NombreFrenteObra = GetDataValue<string>(dr, "NombreFrenteObra"),
                NumeroFrenteObra = GetDataValue<string>(dr, "NumeroFrenteObra"),
                NombreGrupoObraTipoProyecto = GetDataValue<string>(dr, "NombreGrupoObra_tipoProyecto"),
                NroGrupoObra = GetDataValue<string>(dr, "NroGrupoObra"),
                RazonSocial = GetDataValue<string>(dr, "RazonSocial"),
                NumeroCUIT = GetDataValue<string>(dr, "NumeroCUIT")
            };
            return result;
        }

        private FrenteObraEstadoNumero ParseFrenteObraGetEstadoNumero()
        {
            // Leer valores.
            var result = new FrenteObraEstadoNumero
            {
                NombreFrenteObra = "PALAIS DE GLACE",
                NumeroFrenteObra = "81-0001-FDO18",
                NombreGrupoObraTipoProyecto = "ARQUITECTURA",
                NroGrupoObra = "81-0009-OBR18",
                RazonSocial = "Constructora Lanusse",
                NumeroCUIT = "30-99999999-2"
            };
            return result;
        }
    }
}
