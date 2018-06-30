using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiAirlineModelMapper
        {
                ApiAirlineResponseModel MapRequestToResponse(
                        int id,
                        ApiAirlineRequestModel request);

                ApiAirlineRequestModel MapResponseToRequest(
                        ApiAirlineResponseModel response);
        }
}

/*<Codenesium>
    <Hash>96293306a29f7d313fcf481f4b2d3fa1</Hash>
</Codenesium>*/