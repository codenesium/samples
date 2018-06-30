using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBillOfMaterialsModelMapper
        {
                public virtual ApiBillOfMaterialsResponseModel MapRequestToResponse(
                        int billOfMaterialsID,
                        ApiBillOfMaterialsRequestModel request)
                {
                        var response = new ApiBillOfMaterialsResponseModel();
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

                public virtual ApiBillOfMaterialsRequestModel MapResponseToRequest(
                        ApiBillOfMaterialsResponseModel response)
                {
                        var request = new ApiBillOfMaterialsRequestModel();
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
        }
}

/*<Codenesium>
    <Hash>ce131cf9122aa98743653a54218970a1</Hash>
</Codenesium>*/