using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class LessonStatusRepository : AbstractLessonStatusRepository, ILessonStatusRepository
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
    <Hash>f14962ec571b0585301d8c7d37eae1ab</Hash>
</Codenesium>*/