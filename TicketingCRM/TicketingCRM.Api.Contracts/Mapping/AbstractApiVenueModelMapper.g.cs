using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiVenueModelMapper
        {
                public virtual ApiVenueResponseModel MapRequestToResponse(
                        int id,
                        ApiVenueRequestModel request)
                {
                        var response = new ApiVenueResponseModel();
                        response.SetProperties(id,
                                               request.Address1,
                                               request.Address2,
                                               request.AdminId,
                                               request.Email,
                                               request.Facebook,
                                               request.Name,
                                               request.Phone,
                                               request.ProvinceId,
                                               request.Website);
                        return response;
                }

                public virtual ApiVenueRequestModel MapResponseToRequest(
                        ApiVenueResponseModel response)
                {
                        var request = new ApiVenueRequestModel();
                        request.SetProperties(
                                response.Address1,
                                response.Address2,
                                response.AdminId,
                                response.Email,
                                response.Facebook,
                                response.Name,
                                response.Phone,
                                response.ProvinceId,
                                response.Website);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>96c0572b3b38973d45149c1f32a477b8</Hash>
</Codenesium>*/