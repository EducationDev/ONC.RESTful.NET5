using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Westwind.Utilities;

namespace ONC.RESTful.API.Common.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public HttpStatusCode Code { get; set; }
        public ValidationErrorCollection Errors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ApiError(string message)
        {
            this.Message = message;
            IsError = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        public ApiError(ModelStateDictionary modelState)
        {
            this.IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                Message = "Please correct the specified errors and try again.";
                //errors = modelState.SelectMany(m => m.Value.Errors).ToDictionary(m => m.Key, m=> m.ErrorMessage);
                //errors = modelState.SelectMany(m => m.Value.Errors.Select( me => new KeyValuePair<string,string>( m.Key,me.ErrorMessage) ));
                //errors = modelState.SelectMany(m => m.Value.Errors.Select(me => new ModelError { FieldName = m.Key, ErrorMessage = me.ErrorMessage }));
            }
        }
    }
}