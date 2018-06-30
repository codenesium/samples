using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesPersonModelMapper
        {
                public virtual ApiSalesPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonRequestModel request)
                {
                        var response = new ApiSalesPersonResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.Bonus,
                                               request.CommissionPct,
                                               request.ModifiedDate,
                                               request.Rowguid,
                                               request.SalesLastYear,
                                               request.SalesQuota,
                                               request.SalesYTD,
                                               request.TerritoryID);
                        return response;
                }

                public virtual ApiSalesPersonRequestModel MapResponseToRequest(
                        ApiSalesPersonResponseModel response)
                {
                        var request = new ApiSalesPersonRequestModel();
                        request.SetProperties(
                                response.Bonus,
                                response.CommissionPct,
                                response.ModifiedDate,
                                response.Rowguid,
                                response.SalesLastYear,
                                response.SalesQuota,
                                response.SalesYTD,
                                response.TerritoryID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9f0b56675d1444966e0ed1a221dc9ea0</Hash>
</Codenesium>*/