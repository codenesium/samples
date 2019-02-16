using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductServerModelMapper
	{
		public virtual ApiProductServerResponseModel MapServerRequestToResponse(
			int productID,
			ApiProductServerRequestModel request)
		{
			var response = new ApiProductServerResponseModel();
			response.SetProperties(productID,
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

		public virtual ApiProductServerRequestModel MapServerResponseToRequest(
			ApiProductServerResponseModel response)
		{
			var request = new ApiProductServerRequestModel();
			request.SetProperties(
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

		public virtual ApiProductClientRequestModel MapServerResponseToClientRequest(
			ApiProductServerResponseModel response)
		{
			var request = new ApiProductClientRequestModel();
			request.SetProperties(
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

		public JsonPatchDocument<ApiProductServerRequestModel> CreatePatch(ApiProductServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductServerRequestModel>();
			patch.Replace(x => x.Color, model.Color);
			patch.Replace(x => x.DaysToManufacture, model.DaysToManufacture);
			patch.Replace(x => x.DiscontinuedDate, model.DiscontinuedDate);
			patch.Replace(x => x.FinishedGoodsFlag, model.FinishedGoodsFlag);
			patch.Replace(x => x.ListPrice, model.ListPrice);
			patch.Replace(x => x.MakeFlag, model.MakeFlag);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProductLine, model.ProductLine);
			patch.Replace(x => x.ProductModelID, model.ProductModelID);
			patch.Replace(x => x.ProductNumber, model.ProductNumber);
			patch.Replace(x => x.ProductSubcategoryID, model.ProductSubcategoryID);
			patch.Replace(x => x.ReorderPoint, model.ReorderPoint);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SafetyStockLevel, model.SafetyStockLevel);
			patch.Replace(x => x.SellEndDate, model.SellEndDate);
			patch.Replace(x => x.SellStartDate, model.SellStartDate);
			patch.Replace(x => x.Size, model.Size);
			patch.Replace(x => x.SizeUnitMeasureCode, model.SizeUnitMeasureCode);
			patch.Replace(x => x.StandardCost, model.StandardCost);
			patch.Replace(x => x.Style, model.Style);
			patch.Replace(x => x.Weight, model.Weight);
			patch.Replace(x => x.WeightUnitMeasureCode, model.WeightUnitMeasureCode);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>94e97c8d6adc51af8489c89377d31cf0</Hash>
</Codenesium>*/