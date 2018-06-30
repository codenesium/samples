using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiLinkStatusModelMapper
        {
                public virtual ApiLinkStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkStatusRequestModel request)
                {
                        var response = new ApiLinkStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiLinkStatusRequestModel MapResponseToRequest(
                        ApiLinkStatusResponseModel response)
                {
                        var request = new ApiLinkStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d0081e8ec8b56d2aa06aacac4aecd405</Hash>
</Codenesium>*/