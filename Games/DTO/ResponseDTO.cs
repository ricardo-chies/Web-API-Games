using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.DTO
{
    public class ResponseDTO<T>
    {
        public List<T> Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
