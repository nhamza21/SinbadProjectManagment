using AutoMapper;
using SinbadProjectManagement.Application.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Tests.Projects.Queries
{
    public class BaseProjectsQueriesTests : BaseProjectTests
    {
        protected IMapper _mapper;
        public BaseProjectsQueriesTests()
        {
            var mapConfiguration = new MapperConfiguration(conf =>
                {
                    conf.AddProfile(new ProjectProfile());
                }
            );

            _mapper = new Mapper(mapConfiguration);
        }
    }
}
