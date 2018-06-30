using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSpecialOfferModelMapper
        {
                ApiSpecialOfferResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel request);

                ApiSpecialOfferRequestModel MapResponseToRequest(
                        ApiSpecialOfferResponseModel response);
        }
}

/*<Codenesium>
    <Hash>16ff6b6b47c1dd13787483f61547faab</Hash>
</Codenesium>*/