using Codenesium.DataConversionExtensions;
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
    <Hash>a1b4b295f98aa300beb6a4c9ce8dbec8</Hash>
</Codenesium>*/