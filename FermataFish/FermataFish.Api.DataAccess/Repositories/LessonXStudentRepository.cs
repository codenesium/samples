using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class LessonXStudentRepository : AbstractLessonXStudentRepository, ILessonXStudentRepository
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
    <Hash>ff820f44e264a00dac12fbfd30f86130</Hash>
</Codenesium>*/