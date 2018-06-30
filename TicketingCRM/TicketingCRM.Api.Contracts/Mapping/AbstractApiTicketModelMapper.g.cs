using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTicketModelMapper
        {
                public virtual ApiTicketResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketRequestModel request)
                {
                        var response = new ApiTicketResponseModel();
                        response.SetProperties(id,
                                               request.PublicId,
                                               request.TicketStatusId);
                        return response;
                }

                public virtual ApiTicketRequestModel MapResponseToRequest(
                        ApiTicketResponseModel response)
                {
                        var request = new ApiTicketRequestModel();
                        request.SetProperties(
                                response.PublicId,
                                response.TicketStatusId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>226bdf8d2145171b55aae39cf7f3d711</Hash>
</Codenesium>*/