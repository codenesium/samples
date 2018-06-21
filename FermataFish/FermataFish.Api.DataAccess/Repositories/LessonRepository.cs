using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonRepository : AbstractLessonRepository, ILessonRepository
        {
                public LessonRepository(
                        ILogger<LessonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5cea0c755274fa188718edb2846a3f9d</Hash>
</Codenesium>*/