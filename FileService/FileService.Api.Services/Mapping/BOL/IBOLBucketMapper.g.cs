using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

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
    <Hash>efe794a0ac136d762fdc4144db078461</Hash>
</Codenesium>*/