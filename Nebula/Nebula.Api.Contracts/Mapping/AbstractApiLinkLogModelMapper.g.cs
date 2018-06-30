using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiLinkLogModelMapper
        {
                public virtual ApiLinkLogResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkLogRequestModel request)
                {
                        var response = new ApiLinkLogResponseModel();
                        response.SetProperties(id,
                                               request.DateEntered,
                                               request.LinkId,
                                               request.Log);
                        return response;
                }

                public virtual ApiLinkLogRequestModel MapResponseToRequest(
                        ApiLinkLogResponseModel response)
                {
                        var request = new ApiLinkLogRequestModel();
                        request.SetProperties(
                                response.DateEntered,
                                response.LinkId,
                                response.Log);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>1849b96a254517356df648ea6ccebdc5</Hash>
</Codenesium>*/