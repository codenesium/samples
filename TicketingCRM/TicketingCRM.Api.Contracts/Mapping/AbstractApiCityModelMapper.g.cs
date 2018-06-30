using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiCityModelMapper
        {
                public virtual ApiCityResponseModel MapRequestToResponse(
                        int id,
                        ApiCityRequestModel request)
                {
                        var response = new ApiCityResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.ProvinceId);
                        return response;
                }

                public virtual ApiCityRequestModel MapResponseToRequest(
                        ApiCityResponseModel response)
                {
                        var request = new ApiCityRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.ProvinceId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7411be75b029ef334fe9635870c6d273</Hash>
</Codenesium>*/