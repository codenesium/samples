using Codenesium.DataConversionExtensions;
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
    <Hash>8acfc1ee14c280b5dc3849df3c01aa17</Hash>
</Codenesium>*/