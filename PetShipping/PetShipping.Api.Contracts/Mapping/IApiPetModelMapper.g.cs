using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
    <Hash>e801b1ebec86d49fd57c2f48b82d686c</Hash>
</Codenesium>*/