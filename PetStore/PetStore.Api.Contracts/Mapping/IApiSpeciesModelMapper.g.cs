using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiSpeciesModelMapper
        {
                ApiSpeciesResponseModel MapRequestToResponse(
                        int id,
                        ApiSpeciesRequestModel request);

                ApiSpeciesRequestModel MapResponseToRequest(
                        ApiSpeciesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>06973d61cfd57954bc3723e52476189b</Hash>
</Codenesium>*/