using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductCostHistoryModelMapper
        {
                public virtual ApiProductCostHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductCostHistoryRequestModel request)
                {
                        var response = new ApiProductCostHistoryResponseModel();
                        response.SetProperties(productID,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.StandardCost,
                                               request.StartDate);
                        return response;
                }

                public virtual ApiProductCostHistoryRequestModel MapResponseToRequest(
                        ApiProductCostHistoryResponseModel response)
                {
                        var request = new ApiProductCostHistoryRequestModel();
                        request.SetProperties(
                                response.EndDate,
                                response.ModifiedDate,
                                response.StandardCost,
                                response.StartDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c8c07e053d6cf6f8b060987ac59d5d4d</Hash>
</Codenesium>*/