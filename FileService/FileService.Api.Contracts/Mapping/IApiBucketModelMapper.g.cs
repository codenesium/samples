using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiBucketModelMapper
        {
                ApiBucketResponseModel MapRequestToResponse(
                        int id,
                        ApiBucketRequestModel request);

                ApiBucketRequestModel MapResponseToRequest(
                        ApiBucketResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fa29145e90b0c64f0b967c5871966d45</Hash>
</Codenesium>*/