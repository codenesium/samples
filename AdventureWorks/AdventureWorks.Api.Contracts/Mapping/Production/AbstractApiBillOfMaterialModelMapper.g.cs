using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBillOfMaterialModelMapper
        {
                public virtual ApiBillOfMaterialResponseModel MapRequestToResponse(
                        int billOfMaterialsID,
                        ApiBillOfMaterialRequestModel request)
                {
                        var response = new ApiBillOfMaterialResponseModel();
                        response.SetProperties(billOfMaterialsID,
                                               request.BOMLevel,
                                               request.ComponentID,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.PerAssemblyQty,
                                               request.ProductAssemblyID,
                                               request.StartDate,
                                               request.UnitMeasureCode);
                        return response;
                }

                public virtual ApiBillOfMaterialRequestModel MapResponseToRequest(
                        ApiBillOfMaterialResponseModel response)
                {
                        var request = new ApiBillOfMaterialRequestModel();
                        request.SetProperties(
                                response.BOMLevel,
                                response.ComponentID,
                                response.EndDate,
                                response.ModifiedDate,
                                response.PerAssemblyQty,
                                response.ProductAssemblyID,
                                response.StartDate,
                                response.UnitMeasureCode);
                        return request;
                }

                public JsonPatchDocument<ApiBillOfMaterialRequestModel> CreatePatch(ApiBillOfMaterialRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBillOfMaterialRequestModel>();
                        patch.Replace(x => x.BOMLevel, model.BOMLevel);
                        patch.Replace(x => x.ComponentID, model.ComponentID);
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.PerAssemblyQty, model.PerAssemblyQty);
                        patch.Replace(x => x.ProductAssemblyID, model.ProductAssemblyID);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        patch.Replace(x => x.UnitMeasureCode, model.UnitMeasureCode);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>b5aa7df3c695d754655cae4dfaf22203</Hash>
</Codenesium>*/