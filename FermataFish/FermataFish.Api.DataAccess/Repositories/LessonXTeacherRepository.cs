using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonXTeacherRepository: AbstractLessonXTeacherRepository, ILessonXTeacherRepository
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
    <Hash>decabb40a7e139b608dcc6f44ad4e74d</Hash>
</Codenesium>*/