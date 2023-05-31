using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public interface IExceptionHandler
    {
        Type ExceptionType {get;} 
        
        ErrorMessage HandleException(Exception exception);
        
    }
}