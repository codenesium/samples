using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSpecialOfferProductModelMapper
        {
                ApiSpecialOfferProductResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel request);

                ApiSpecialOfferProductRequestModel MapResponseToRequest(
                        ApiSpecialOfferProductResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f97bf8059a2a65098a0d2641031c78c9</Hash>
</Codenesium>*/