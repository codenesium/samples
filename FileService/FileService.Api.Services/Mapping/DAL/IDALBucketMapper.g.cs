using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>5d39ab629a0e357e4adcc228e477de00</Hash>
</Codenesium>*/