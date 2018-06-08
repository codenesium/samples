using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class BucketService: AbstractBucketService, IBucketService
        {
                public BucketService(
                        ILogger<BucketRepository> logger,
                        IBucketRepository bucketRepository,
                        IApiBucketRequestModelValidator bucketModelValidator,
                        IBOLBucketMapper bolbucketMapper,
                        IDALBucketMapper dalbucketMapper)
                        : base(logger,
                               bucketRepository,
                               bucketModelValidator,
                               bolbucketMapper,
                               dalbucketMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>35fca699e97ce4e9f1ad3c159485801d</Hash>
</Codenesium>*/