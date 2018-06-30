using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiScrapReasonModelMapper
        {
                ApiScrapReasonResponseModel MapRequestToResponse(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel request);

                ApiScrapReasonRequestModel MapResponseToRequest(
                        ApiScrapReasonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>59b1c453f846377793f771265759cb8c</Hash>
</Codenesium>*/