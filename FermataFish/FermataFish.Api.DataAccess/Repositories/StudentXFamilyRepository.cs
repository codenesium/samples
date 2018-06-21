using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StudentXFamilyRepository : AbstractStudentXFamilyRepository, IStudentXFamilyRepository
        {
                public StudentXFamilyRepository(
                        ILogger<StudentXFamilyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>41347cf065ae96ad704e55e3181940a7</Hash>
</Codenesium>*/