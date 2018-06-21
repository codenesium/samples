using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
        public interface IBOLBucketMapper
        {
                BOBucket MapModelToBO(
                        int id,
                        ApiBucketRequestModel model);

                ApiBucketResponseModel MapBOToModel(
                        BOBucket boBucket);

                List<ApiBucketResponseModel> MapBOToModel(
                        List<BOBucket> items);
        }
}

/*<Codenesium>
    <Hash>ef9a68146d602856b62aaaa4dbdec988</Hash>
</Codenesium>*/