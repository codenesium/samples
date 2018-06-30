using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiOrganizationModelMapper
        {
                public virtual ApiOrganizationResponseModel MapRequestToResponse(
                        int id,
                        ApiOrganizationRequestModel request)
                {
                        var response = new ApiOrganizationResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiOrganizationRequestModel MapResponseToRequest(
                        ApiOrganizationResponseModel response)
                {
                        var request = new ApiOrganizationRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8e589cc9351e4943860ace0f5218bb50</Hash>
</Codenesium>*/