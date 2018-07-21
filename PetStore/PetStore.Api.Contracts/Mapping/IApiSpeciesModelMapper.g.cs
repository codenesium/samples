using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
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
    <Hash>778fda3bb05a8154ef5b52bdf2b2d217</Hash>
</Codenesium>*/