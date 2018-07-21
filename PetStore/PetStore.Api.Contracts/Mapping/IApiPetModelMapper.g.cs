using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPetModelMapper
        {
                ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request);

                ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response);

                JsonPatchDocument<ApiPetRequestModel> CreatePatch(ApiPetRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c0b26efd909bca020b5a380f3c1054bf</Hash>
</Codenesium>*/