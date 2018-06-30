using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiAdminModelMapper
        {
                public virtual ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request)
                {
                        var response = new ApiAdminResponseModel();
                        response.SetProperties(id,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Password,
                                               request.Phone,
                                               request.Username);
                        return response;
                }

                public virtual ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response)
                {
                        var request = new ApiAdminRequestModel();
                        request.SetProperties(
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Password,
                                response.Phone,
                                response.Username);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>501e58f89184ea41cfeb381507a63ce7</Hash>
</Codenesium>*/