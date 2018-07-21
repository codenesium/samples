using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiSpeciesModelMapper
        {
                ApiSpeciesResponseModel MapRequestToResponse(
                        int id,
                        ApiSpeciesRequestModel request);

                ApiSpeciesRequestModel MapResponseToRequest(
                        ApiSpeciesResponseModel response);

                JsonPatchDocument<ApiSpeciesRequestModel> CreatePatch(ApiSpeciesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ad921f93ce72e16bba5190fb51f40d74</Hash>
</Codenesium>*/