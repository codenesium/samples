using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiProvinceModelMapper
        {
                public virtual ApiProvinceResponseModel MapRequestToResponse(
                        int id,
                        ApiProvinceRequestModel request)
                {
                        var response = new ApiProvinceResponseModel();
                        response.SetProperties(id,
                                               request.CountryId,
                                               request.Name);
                        return response;
                }

                public virtual ApiProvinceRequestModel MapResponseToRequest(
                        ApiProvinceResponseModel response)
                {
                        var request = new ApiProvinceRequestModel();
                        request.SetProperties(
                                response.CountryId,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>346e3a5f1d8ae9eab3d79355575166d7</Hash>
</Codenesium>*/