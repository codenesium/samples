using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherRepository: AbstractTeacherRepository, ITeacherRepository
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
    <Hash>7a004a652704742b686e4444bd8a9ae9</Hash>
</Codenesium>*/