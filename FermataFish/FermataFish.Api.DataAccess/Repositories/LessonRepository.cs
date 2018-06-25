using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class LessonRepository : AbstractLessonRepository, ILessonRepository
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
    <Hash>6ab4d42bfc79fc4fc37381523efdd1e4</Hash>
</Codenesium>*/