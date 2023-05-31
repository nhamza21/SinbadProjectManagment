using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public interface IExceptionHandlersBuilder
    {
        IExceptionHandlersBuilder AddHandler<TExceptionHandler>()
            where TExceptionHandler : IExceptionHandler;
        void Build();
    }
}