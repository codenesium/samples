using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IDALBucketMapper
        {
                Bucket MapBOToEF(
                        BOBucket bo);

                BOBucket MapEFToBO(
                        Bucket efBucket);

                List<BOBucket> MapEFToBO(
                        List<Bucket> records);
        }
}

/*<Codenesium>
    <Hash>a98bb08864a64225dea5c184dd01082f</Hash>
</Codenesium>*/