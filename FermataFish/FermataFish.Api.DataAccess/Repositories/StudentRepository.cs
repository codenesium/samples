using Codenesium.DataConversionExtensions;
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
    <Hash>003c19bf83492b72e19bb5cdbed67c3c</Hash>
</Codenesium>*/