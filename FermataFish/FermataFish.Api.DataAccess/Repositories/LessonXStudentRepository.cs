using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>2dca587c1cde291eb35791081fb20967</Hash>
</Codenesium>*/