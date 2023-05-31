using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public interface IExceptionHandlersProvider
    {
        IExceptionHandler GetHandler(Type exceptionType);
    }
}