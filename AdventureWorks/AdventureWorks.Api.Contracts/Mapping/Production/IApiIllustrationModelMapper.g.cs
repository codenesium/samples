using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiIllustrationModelMapper
        {
                ApiIllustrationResponseModel MapRequestToResponse(
                        int illustrationID,
                        ApiIllustrationRequestModel request);

                ApiIllustrationRequestModel MapResponseToRequest(
                        ApiIllustrationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>02af830870d26e5e0aac46f8a6f28e17</Hash>
</Codenesium>*/