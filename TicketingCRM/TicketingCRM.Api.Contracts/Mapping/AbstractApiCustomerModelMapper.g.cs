using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiCustomerModelMapper
        {
                public virtual ApiCustomerResponseModel MapRequestToResponse(
                        int id,
                        ApiCustomerRequestModel request)
                {
                        var response = new ApiCustomerResponseModel();
                        response.SetProperties(id,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Phone);
                        return response;
                }

                public virtual ApiCustomerRequestModel MapResponseToRequest(
                        ApiCustomerResponseModel response)
                {
                        var request = new ApiCustomerRequestModel();
                        request.SetProperties(
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Phone);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d6ac90e809b8c8f45b0a3e94c4c89dad</Hash>
</Codenesium>*/