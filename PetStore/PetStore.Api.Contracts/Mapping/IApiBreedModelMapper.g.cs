using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
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
    <Hash>e088adf1bf85f36bed35da53116e8d05</Hash>
</Codenesium>*/