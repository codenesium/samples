using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiDestinationModelMapper
        {
                ApiDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiDestinationRequestModel request);

                ApiDestinationRequestModel MapResponseToRequest(
                        ApiDestinationResponseModel response);

                JsonPatchDocument<ApiDestinationRequestModel> CreatePatch(ApiDestinationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6e09b8c3c519c8a321fe6dfa30aa3bee</Hash>
</Codenesium>*/