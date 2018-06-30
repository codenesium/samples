using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesTerritoryHistoryModelMapper
        {
                public virtual ApiSalesTerritoryHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesTerritoryHistoryRequestModel request)
                {
                        var response = new ApiSalesTerritoryHistoryResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.Rowguid,
                                               request.StartDate,
                                               request.TerritoryID);
                        return response;
                }

                public virtual ApiSalesTerritoryHistoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryHistoryResponseModel response)
                {
                        var request = new ApiSalesTerritoryHistoryRequestModel();
                        request.SetProperties(
                                response.EndDate,
                                response.ModifiedDate,
                                response.Rowguid,
                                response.StartDate,
                                response.TerritoryID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e5346a5808af16b740fc98e6c958f265</Hash>
</Codenesium>*/