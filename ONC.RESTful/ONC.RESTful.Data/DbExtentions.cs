using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;


namespace ONC.RESTful.Data
{
    public static class DbExtentions
    {
        /// <summary>
        /// Iterara sobre los campos de un datareader y devuelve un objeto expando
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <returns>ExpandoObject</returns>
        public static dynamic ToExpando(this IDataReader reader)
        {
            var dictionary = new ExpandoObject() as IDictionary<string, object>;
            for (var i = 0; i < reader.FieldCount; i++)
                dictionary.Add(reader.GetName(i), reader[i] == DBNull.Value ? null : reader[i]);
            return (ExpandoObject)dictionary;
        }
    }
}
