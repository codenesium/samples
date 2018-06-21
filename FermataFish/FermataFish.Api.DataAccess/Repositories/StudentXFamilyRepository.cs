using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>bf2d39108b5b99b3440311343e7f4e27</Hash>
</Codenesium>*/