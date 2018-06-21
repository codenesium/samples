using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>53dedea86e8f5f5731edc0a188c6743f</Hash>
</Codenesium>*/