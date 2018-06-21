using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class BucketRepository : AbstractBucketRepository, IBucketRepository
        {
                public BucketRepository(
                        ILogger<BucketRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d6e3b26b18373d8078ce13da1a9f26c9</Hash>
</Codenesium>*/