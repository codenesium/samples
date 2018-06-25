using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class StudentRepository : AbstractStudentRepository, IStudentRepository
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
    <Hash>80a900e1e9832eb9f46173278db3d53c</Hash>
</Codenesium>*/