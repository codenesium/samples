using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiAirlineModelMapper
        {
                ApiAirlineResponseModel MapRequestToResponse(
                        int id,
                        ApiAirlineRequestModel request);

                ApiAirlineRequestModel MapResponseToRequest(
                        ApiAirlineResponseModel response);

                JsonPatchDocument<ApiAirlineRequestModel> CreatePatch(ApiAirlineRequestModel model);
        }
}

/*<Codenesium>
    <Hash>413267c5938fd8ca8f8b09f7e9b10f5c</Hash>
</Codenesium>*/