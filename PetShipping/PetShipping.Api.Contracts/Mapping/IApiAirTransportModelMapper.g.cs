using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiAirTransportModelMapper
        {
                ApiAirTransportResponseModel MapRequestToResponse(
                        int airlineId,
                        ApiAirTransportRequestModel request);

                ApiAirTransportRequestModel MapResponseToRequest(
                        ApiAirTransportResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fcdd218091743173b1a24ce58c1ced4d</Hash>
</Codenesium>*/