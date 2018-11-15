using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductModelMapper
	{
		public virtual ApiProductClientResponseModel MapClientRequestToResponse(
			int productID,
			ApiProductClientRequestModel request)
		{
			var response = new ApiProductClientResponseModel();
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

		public virtual ApiProductClientRequestModel MapClientResponseToRequest(
			ApiProductClientResponseModel response)
		{
			var request = new ApiProductClientRequestModel();
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
    <Hash>b69736f852895046f3295ad0d4325313</Hash>
</Codenesium>*/