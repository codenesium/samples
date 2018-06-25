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
        public partial class BucketService : AbstractBucketService, IBucketService
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
    <Hash>f82afeb22532cf8e3ff3fba981800d31</Hash>
</Codenesium>*/