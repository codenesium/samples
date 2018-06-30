using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPetModelMapper
        {
                ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request);

                ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5345fcb4055872e04b56d6ecc1ecdecd</Hash>
</Codenesium>*/