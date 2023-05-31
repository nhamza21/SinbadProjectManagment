using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public int Code {get;}
        public NotFoundException(string name, object key, int code)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            Code = code;
        }
    }
}