using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiRateModelMapper
        {
                ApiRateResponseModel MapRequestToResponse(
                        int id,
                        ApiRateRequestModel request);

                ApiRateRequestModel MapResponseToRequest(
                        ApiRateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d48fda89b0c56b0500ae4a5494990a53</Hash>
</Codenesium>*/