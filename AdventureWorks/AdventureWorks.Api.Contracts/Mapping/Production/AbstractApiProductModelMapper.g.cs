using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelMapper
        {
                public virtual ApiProductResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductRequestModel request)
                {
                        var response = new ApiProductResponseModel();
                        response.SetProperties(productID,
                                               request.@Class,
                                               request.Color,
                                               request.DaysToManufacture,
                                               request.DiscontinuedDate,
                                               request.FinishedGoodsFlag,
                                               request.ListPrice,
                                               request.MakeFlag,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.ProductLine,
                                               request.ProductModelID,
                                               request.ProductNumber,
                                               request.ProductSubcategoryID,
                                               request.ReorderPoint,
                                               request.Rowguid,
                                               request.SafetyStockLevel,
                                               request.SellEndDate,
                                               request.SellStartDate,
                                               request.Size,
                                               request.SizeUnitMeasureCode,
                                               request.StandardCost,
                                               request.Style,
                                               request.Weight,
                                               request.WeightUnitMeasureCode);
                        return response;
                }

                public virtual ApiProductRequestModel MapResponseToRequest(
                        ApiProductResponseModel response)
                {
                        var request = new ApiProductRequestModel();
                        request.SetProperties(
                                response.@Class,
                                response.Color,
                                response.DaysToManufacture,
                                response.DiscontinuedDate,
                                response.FinishedGoodsFlag,
                                response.ListPrice,
                                response.MakeFlag,
                                response.ModifiedDate,
                                response.Name,
                                response.ProductLine,
                                response.ProductModelID,
                                response.ProductNumber,
                                response.ProductSubcategoryID,
                                response.ReorderPoint,
                                response.Rowguid,
                                response.SafetyStockLevel,
                                response.SellEndDate,
                                response.SellStartDate,
                                response.Size,
                                response.SizeUnitMeasureCode,
                                response.StandardCost,
                                response.Style,
                                response.Weight,
                                response.WeightUnitMeasureCode);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>76bbec2e636bf9fa97cbfeb34efa7093</Hash>
</Codenesium>*/