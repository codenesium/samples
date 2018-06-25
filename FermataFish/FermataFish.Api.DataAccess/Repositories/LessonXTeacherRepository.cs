using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class LessonXTeacherRepository : AbstractLessonXTeacherRepository, ILessonXTeacherRepository
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
    <Hash>d30b4bc63888c67d0844580d52875de9</Hash>
</Codenesium>*/