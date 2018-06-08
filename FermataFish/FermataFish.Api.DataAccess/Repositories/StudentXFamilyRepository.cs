using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StudentXFamilyRepository: AbstractStudentXFamilyRepository, IStudentXFamilyRepository
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
    <Hash>ed7740068224e4401251362a60fb38b0</Hash>
</Codenesium>*/