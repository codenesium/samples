using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonXStudentRepository : AbstractLessonXStudentRepository, ILessonXStudentRepository
        {
                public LessonXStudentRepository(
                        ILogger<LessonXStudentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f49a483276d2e2139308ae5f685b8444</Hash>
</Codenesium>*/