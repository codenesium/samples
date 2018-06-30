using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiEventModelMapper
        {
                public virtual ApiEventResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRequestModel request)
                {
                        var response = new ApiEventResponseModel();
                        response.SetProperties(id,
                                               request.Address1,
                                               request.Address2,
                                               request.CityId,
                                               request.Date,
                                               request.Description,
                                               request.EndDate,
                                               request.Facebook,
                                               request.Name,
                                               request.StartDate,
                                               request.Website);
                        return response;
                }

                public virtual ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response)
                {
                        var request = new ApiEventRequestModel();
                        request.SetProperties(
                                response.Address1,
                                response.Address2,
                                response.CityId,
                                response.Date,
                                response.Description,
                                response.EndDate,
                                response.Facebook,
                                response.Name,
                                response.StartDate,
                                response.Website);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>045032c37869c86dce2f4048a1ef6ab0</Hash>
</Codenesium>*/