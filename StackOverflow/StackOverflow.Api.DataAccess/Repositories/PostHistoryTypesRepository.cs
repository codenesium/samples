using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class PostHistoryTypesRepository : AbstractPostHistoryTypesRepository, IPostHistoryTypesRepository
        {
                public PostHistoryTypesRepository(
                        ILogger<PostHistoryTypesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>efd02039c29c673341cae14b723b6afd</Hash>
</Codenesium>*/