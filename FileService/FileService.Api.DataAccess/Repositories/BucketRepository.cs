using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public partial class BucketRepository : AbstractBucketRepository, IBucketRepository
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
    <Hash>0c3e133ae1d91f727ce038e3fd18a990</Hash>
</Codenesium>*/