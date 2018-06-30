using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
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
    <Hash>0b870d8a0ee39659145a7d08bfabf529</Hash>
</Codenesium>*/