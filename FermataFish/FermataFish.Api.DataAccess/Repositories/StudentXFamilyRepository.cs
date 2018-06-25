using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class StudentXFamilyRepository : AbstractStudentXFamilyRepository, IStudentXFamilyRepository
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
    <Hash>0cce0d07b9b0b6b51f7f7957f1da2b91</Hash>
</Codenesium>*/