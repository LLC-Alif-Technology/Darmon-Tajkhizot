using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Entities.DataTransferObjects.Errors
{
    public class ExceptionWithStatusCode:Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ExceptionWithStatusCode(HttpStatusCode statusCode, string message):base(message) 
        {
            StatusCode = statusCode;
        }
    }
}
