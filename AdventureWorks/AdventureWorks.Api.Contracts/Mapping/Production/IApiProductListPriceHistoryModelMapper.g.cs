using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductListPriceHistoryModelMapper
        {
                ApiProductListPriceHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductListPriceHistoryRequestModel request);

                ApiProductListPriceHistoryRequestModel MapResponseToRequest(
                        ApiProductListPriceHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>796c63a3ceb647be356e1cba1d177a14</Hash>
</Codenesium>*/