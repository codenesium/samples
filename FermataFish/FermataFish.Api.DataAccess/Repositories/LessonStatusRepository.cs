using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class LessonStatusRepository : AbstractLessonStatusRepository, ILessonStatusRepository
        {
                public LessonStatusRepository(
                        ILogger<LessonStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>dfd8c35b50e5389188ffda9508329f5f</Hash>
</Codenesium>*/