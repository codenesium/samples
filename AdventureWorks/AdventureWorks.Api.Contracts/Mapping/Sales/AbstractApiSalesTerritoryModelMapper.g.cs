using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiSalesTerritoryRequestModel> CreatePatch(ApiSalesTerritoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesTerritoryRequestModel>();
                        patch.Replace(x => x.CostLastYear, model.CostLastYear);
                        patch.Replace(x => x.CostYTD, model.CostYTD);
                        patch.Replace(x => x.CountryRegionCode, model.CountryRegionCode);
                        patch.Replace(x => x.@Group, model.@Group);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.SalesLastYear, model.SalesLastYear);
                        patch.Replace(x => x.SalesYTD, model.SalesYTD);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>78ae9377b54acae1521f949d19a2e86d</Hash>
</Codenesium>*/