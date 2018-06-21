using Codenesium.DataConversionExtensions;
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
    <Hash>8e1c8be34afff413393cd6e2ccf4e69d</Hash>
</Codenesium>*/