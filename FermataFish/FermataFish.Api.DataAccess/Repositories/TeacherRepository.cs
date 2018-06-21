using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>97f0da1d76e8cc617992ab57bc936563</Hash>
</Codenesium>*/