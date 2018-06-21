using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonXTeacherRepository : AbstractLessonXTeacherRepository, ILessonXTeacherRepository
        {
                public LessonXTeacherRepository(
                        ILogger<LessonXTeacherRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>58d64e86a0fc1b0ba0caf8bf9dc04226</Hash>
</Codenesium>*/