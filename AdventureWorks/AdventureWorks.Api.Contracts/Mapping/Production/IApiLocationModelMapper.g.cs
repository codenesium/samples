using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiLocationModelMapper
        {
                ApiLocationResponseModel MapRequestToResponse(
                        short locationID,
                        ApiLocationRequestModel request);

                ApiLocationRequestModel MapResponseToRequest(
                        ApiLocationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>894177c2b641e03181bbb2f6b0f84616</Hash>
</Codenesium>*/