using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StudentRepository: AbstractStudentRepository, IStudentRepository
        {
                public StudentRepository(
                        ILogger<StudentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>42e40e1d4d3c1913be699998b3cae6a5</Hash>
</Codenesium>*/