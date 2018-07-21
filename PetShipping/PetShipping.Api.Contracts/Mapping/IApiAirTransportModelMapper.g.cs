using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiAirTransportModelMapper
        {
                ApiAirTransportResponseModel MapRequestToResponse(
                        int airlineId,
                        ApiAirTransportRequestModel request);

                ApiAirTransportRequestModel MapResponseToRequest(
                        ApiAirTransportResponseModel response);

                JsonPatchDocument<ApiAirTransportRequestModel> CreatePatch(ApiAirTransportRequestModel model);
        }
}

/*<Codenesium>
    <Hash>536a1f6fa68eff56b8cd52b1b7ffed52</Hash>
</Codenesium>*/