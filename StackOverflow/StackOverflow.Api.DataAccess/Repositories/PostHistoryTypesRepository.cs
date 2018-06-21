using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class PostHistoryTypesRepository : AbstractPostHistoryTypesRepository, IPostHistoryTypesRepository
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
    <Hash>fcecfcc8f2b83f5fb447e4a14007bb90</Hash>
</Codenesium>*/