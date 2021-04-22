//====================================================================================================
// Data Access Component
// ONC.RESTful.Data
//
// Generado por vcontreras on 19/12/2020
//====================================================================================================

using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using ONC.RESTful.Tools.Configurations;

namespace ONC.RESTful.Data
{
    /// <summary>
    /// Clase Base del componente de acceso a datos.
    /// </summary>
    public abstract class DataAccessComponent
    {
        protected const string CONNECTION_NAME = "default";
        protected static string ConnectionString;

        static DataAccessComponent()
        {
            // Enterprise Library DAAB - Database Factories.
            var configuration = ConfigurationHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            ConnectionString = configuration.GetConnectionString(CONNECTION_NAME);

        }

        protected int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            var i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}

