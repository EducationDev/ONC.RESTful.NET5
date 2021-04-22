using System.ComponentModel.DataAnnotations;

namespace ONC.RESTful.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class FrenteObraEstadoNumero
    {

        /// <summary>
        /// Valor alfanumérico que representa el Nombre del Frente de Obra
        /// </summary>
        [DataType(DataType.Text)]
        public string NombreFrenteObra { get; set; }

        /// <summary>
        /// Valor alfanumérico que representa el Número del Frente de Obra
        /// </summary>
        [DataType(DataType.Text)] 
        public string NumeroFrenteObra { get; set; }

        /// <summary>
        /// Valor alfanumérico que representa el Nombre Grupo de Obra y Tipo Proyecto
        /// </summary>
        [DataType(DataType.Text)] 
        public string NombreGrupoObraTipoProyecto { get; set; }

        /// <summary>
        /// Valor alfanumérico que representa el Número Grupo de Obra
        /// </summary>
        [DataType(DataType.Text)] 
        public string NroGrupoObra { get; set; }

        /// <summary>
        /// Valor de cadena que representa la Razón Social
        /// </summary>
        [DataType(DataType.Text)] 
        public string RazonSocial { get; set; }

        /// <summary>
        /// Valor alfanumérico que representa el Número de CUIT
        /// </summary>
        [DataType(DataType.Text)] 
        public string NumeroCUIT { get; set; }

    }
}
