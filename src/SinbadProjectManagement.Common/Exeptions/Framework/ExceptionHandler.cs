using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public abstract class ExceptionHandler<TException> : IExceptionHandler 
        where TException : Exception
    {
        public Type ExceptionType => typeof(TException);

        public abstract ErrorMessage HandleException(Exception exception);
    }
}