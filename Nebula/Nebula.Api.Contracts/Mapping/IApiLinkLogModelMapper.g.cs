using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkLogModelMapper
        {
                ApiLinkLogResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkLogRequestModel request);

                ApiLinkLogRequestModel MapResponseToRequest(
                        ApiLinkLogResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9055262fd2738f57a4964496d0ba8413</Hash>
</Codenesium>*/