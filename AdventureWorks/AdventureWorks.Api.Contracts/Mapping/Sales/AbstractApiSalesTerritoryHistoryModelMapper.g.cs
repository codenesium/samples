using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiSalesTerritoryHistoryRequestModel> CreatePatch(ApiSalesTerritoryHistoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSalesTerritoryHistoryRequestModel>();
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        patch.Replace(x => x.TerritoryID, model.TerritoryID);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>78bf21592c8e49846fce11fd2a22d0f5</Hash>
</Codenesium>*/