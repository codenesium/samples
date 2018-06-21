using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StudentRepository : AbstractStudentRepository, IStudentRepository
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
    <Hash>61be8d5e916805941fb38398aae580d8</Hash>
</Codenesium>*/