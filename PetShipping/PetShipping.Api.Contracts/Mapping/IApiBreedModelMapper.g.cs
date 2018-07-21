using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiBreedModelMapper
        {
                ApiBreedResponseModel MapRequestToResponse(
                        int id,
                        ApiBreedRequestModel request);

                ApiBreedRequestModel MapResponseToRequest(
                        ApiBreedResponseModel response);

                JsonPatchDocument<ApiBreedRequestModel> CreatePatch(ApiBreedRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6137e2497ddbba429cc0591659499bb0</Hash>
</Codenesium>*/