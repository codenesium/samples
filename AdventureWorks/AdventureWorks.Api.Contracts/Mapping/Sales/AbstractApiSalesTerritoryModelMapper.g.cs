using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesTerritoryModelMapper
        {
                public virtual ApiSalesTerritoryResponseModel MapRequestToResponse(
                        int territoryID,
                        ApiSalesTerritoryRequestModel request)
                {
                        var response = new ApiSalesTerritoryResponseModel();
                        response.SetProperties(territoryID,
                                               request.CostLastYear,
                                               request.CostYTD,
                                               request.CountryRegionCode,
                                               request.@Group,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid,
                                               request.SalesLastYear,
                                               request.SalesYTD);
                        return response;
                }

                public virtual ApiSalesTerritoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryResponseModel response)
                {
                        var request = new ApiSalesTerritoryRequestModel();
                        request.SetProperties(
                                response.CostLastYear,
                                response.CostYTD,
                                response.CountryRegionCode,
                                response.@Group,
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid,
                                response.SalesLastYear,
                                response.SalesYTD);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0eed3ccb15c0bfc16da1ab309b004ef9</Hash>
</Codenesium>*/