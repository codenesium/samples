using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductListPriceHistoryModelMapper
        {
                public virtual ApiProductListPriceHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductListPriceHistoryRequestModel request)
                {
                        var response = new ApiProductListPriceHistoryResponseModel();
                        response.SetProperties(productID,
                                               request.EndDate,
                                               request.ListPrice,
                                               request.ModifiedDate,
                                               request.StartDate);
                        return response;
                }

                public virtual ApiProductListPriceHistoryRequestModel MapResponseToRequest(
                        ApiProductListPriceHistoryResponseModel response)
                {
                        var request = new ApiProductListPriceHistoryRequestModel();
                        request.SetProperties(
                                response.EndDate,
                                response.ListPrice,
                                response.ModifiedDate,
                                response.StartDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>05585ee1e9646ed5ff04b2c7432d550b</Hash>
</Codenesium>*/