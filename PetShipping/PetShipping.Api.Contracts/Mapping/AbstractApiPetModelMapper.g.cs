using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPetModelMapper
        {
                public virtual ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request)
                {
                        var response = new ApiPetResponseModel();
                        response.SetProperties(id,
                                               request.BreedId,
                                               request.ClientId,
                                               request.Name,
                                               request.Weight);
                        return response;
                }

                public virtual ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response)
                {
                        var request = new ApiPetRequestModel();
                        request.SetProperties(
                                response.BreedId,
                                response.ClientId,
                                response.Name,
                                response.Weight);
                        return request;
                }

                public JsonPatchDocument<ApiPetRequestModel> CreatePatch(ApiPetRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPetRequestModel>();
                        patch.Replace(x => x.BreedId, model.BreedId);
                        patch.Replace(x => x.ClientId, model.ClientId);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Weight, model.Weight);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>144e052185e0efb672d2e65d0a4bf276</Hash>
</Codenesium>*/