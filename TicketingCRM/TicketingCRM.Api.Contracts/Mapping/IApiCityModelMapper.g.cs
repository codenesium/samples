using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCityModelMapper
        {
                ApiCityResponseModel MapRequestToResponse(
                        int id,
                        ApiCityRequestModel request);

                ApiCityRequestModel MapResponseToRequest(
                        ApiCityResponseModel response);
        }
}

/*<Codenesium>
    <Hash>cb03fe55b20f4951ca0f8fc57040ef5d</Hash>
</Codenesium>*/