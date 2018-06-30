using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPenModelMapper
        {
                ApiPenResponseModel MapRequestToResponse(
                        int id,
                        ApiPenRequestModel request);

                ApiPenRequestModel MapResponseToRequest(
                        ApiPenResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9eb4e3002e445112c1cf7ac5b6e299e3</Hash>
</Codenesium>*/