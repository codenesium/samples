using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonRepository: AbstractLessonRepository, ILessonRepository
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
    <Hash>e1e2b6ac1fbb909d444af1861b1698cb</Hash>
</Codenesium>*/