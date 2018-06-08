using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class BucketRepository: AbstractBucketRepository, IBucketRepository
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
    <Hash>6c395f294d1b4635bce2fb17da06c233</Hash>
</Codenesium>*/