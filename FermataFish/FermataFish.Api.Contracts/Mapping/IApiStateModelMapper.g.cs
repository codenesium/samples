using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStateModelMapper
        {
                ApiStateResponseModel MapRequestToResponse(
                        int id,
                        ApiStateRequestModel request);

                ApiStateRequestModel MapResponseToRequest(
                        ApiStateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>bdd55eb06cac723021e1f7af4903b52b</Hash>
</Codenesium>*/