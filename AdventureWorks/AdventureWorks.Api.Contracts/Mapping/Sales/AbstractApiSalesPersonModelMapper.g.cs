using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiSalesPersonRequestModel> CreatePatch(ApiSalesPersonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesPersonRequestModel>();
                        patch.Replace(x => x.Bonus, model.Bonus);
                        patch.Replace(x => x.CommissionPct, model.CommissionPct);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.SalesLastYear, model.SalesLastYear);
                        patch.Replace(x => x.SalesQuota, model.SalesQuota);
                        patch.Replace(x => x.SalesYTD, model.SalesYTD);
                        patch.Replace(x => x.TerritoryID, model.TerritoryID);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>5ae17306dc38bc02ad0c4fd6af77412d</Hash>
</Codenesium>*/