using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherRepository : AbstractTeacherRepository, ITeacherRepository
        {
                public TeacherRepository(
                        ILogger<TeacherRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7fdcfd2d73698a4f1fc2736af355efef</Hash>
</Codenesium>*/