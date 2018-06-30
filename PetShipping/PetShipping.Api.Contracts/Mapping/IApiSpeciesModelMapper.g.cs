using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
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
    <Hash>1765fcb8cae11cfe3555ab21da1d8e89</Hash>
</Codenesium>*/