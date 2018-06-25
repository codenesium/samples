using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class CommentsRepository : AbstractCommentsRepository, ICommentsRepository
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
    <Hash>75d4497b4fd46494d34de4a43f6648bf</Hash>
</Codenesium>*/