using Codenesium.DataConversionExtensions;
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
    <Hash>1deee67a790bc093e67a4790a5e4ff40</Hash>
</Codenesium>*/