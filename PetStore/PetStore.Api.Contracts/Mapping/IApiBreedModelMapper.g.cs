using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiBreedModelMapper
        {
                ApiBreedResponseModel MapRequestToResponse(
                        int id,
                        ApiBreedRequestModel request);

                ApiBreedRequestModel MapResponseToRequest(
                        ApiBreedResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f804f5cfb333a23384ea780c879cdcf3</Hash>
</Codenesium>*/