using Codenesium.DataConversionExtensions.AspNetCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
{
        public class BucketService : AbstractBucketService, IBucketService
        {
                public BucketService(
                        ILogger<IBucketRepository> logger,
                        IBucketRepository bucketRepository,
                        IApiBucketRequestModelValidator bucketModelValidator,
                        IBOLBucketMapper bolbucketMapper,
                        IDALBucketMapper dalbucketMapper,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper
                        )
                        : base(logger,
                               bucketRepository,
                               bucketModelValidator,
                               bolbucketMapper,
                               dalbucketMapper,
                               bolFileMapper,
                               dalFileMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f782eed7dd6fef575b99de9e8d3eca32</Hash>
</Codenesium>*/