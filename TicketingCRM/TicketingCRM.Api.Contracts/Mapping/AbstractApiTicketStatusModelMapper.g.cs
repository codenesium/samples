using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTicketStatusModelMapper
        {
                public virtual ApiTicketStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketStatusRequestModel request)
                {
                        var response = new ApiTicketStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiTicketStatusRequestModel MapResponseToRequest(
                        ApiTicketStatusResponseModel response)
                {
                        var request = new ApiTicketStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>4b1ed5c40ffd4b2328ec5cc4c4902f69</Hash>
</Codenesium>*/