using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiVersionInfoModelMapper
        {
                public virtual ApiVersionInfoResponseModel MapRequestToResponse(
                        long version,
                        ApiVersionInfoRequestModel request)
                {
                        var response = new ApiVersionInfoResponseModel();
                        response.SetProperties(version,
                                               request.AppliedOn,
                                               request.Description);
                        return response;
                }

                public virtual ApiVersionInfoRequestModel MapResponseToRequest(
                        ApiVersionInfoResponseModel response)
                {
                        var request = new ApiVersionInfoRequestModel();
                        request.SetProperties(
                                response.AppliedOn,
                                response.Description);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>2b949b10bbcd73c084b36af0fe9704f2</Hash>
</Codenesium>*/