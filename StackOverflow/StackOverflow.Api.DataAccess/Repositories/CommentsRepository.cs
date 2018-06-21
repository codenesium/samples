using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class CommentsRepository : AbstractCommentsRepository, ICommentsRepository
        {
                public CommentsRepository(
                        ILogger<CommentsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>efdd4321f2d42783a0b7effc7c0711df</Hash>
</Codenesium>*/