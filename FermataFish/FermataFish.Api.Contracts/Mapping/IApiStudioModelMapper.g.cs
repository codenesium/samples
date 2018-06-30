using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudioModelMapper
        {
                ApiStudioResponseModel MapRequestToResponse(
                        int id,
                        ApiStudioRequestModel request);

                ApiStudioRequestModel MapResponseToRequest(
                        ApiStudioResponseModel response);
        }
}

/*<Codenesium>
    <Hash>c4328b1e917d80c3464a4e0a96d892d4</Hash>
</Codenesium>*/