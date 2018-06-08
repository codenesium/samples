using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonXStudentRepository: AbstractLessonXStudentRepository, ILessonXStudentRepository
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
    <Hash>5117eec572bc4ab8c9d4ac502205add2</Hash>
</Codenesium>*/