using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductMapper
	{
		public virtual BOProduct MapModelToBO(
			int productID,
			ApiProductServerRequestModel model
			)
		{
			BOProduct boProduct = new BOProduct();
			boProduct.SetProperties(
				productID,
				model.@Class,
				model.Color,
				model.DaysToManufacture,
				model.DiscontinuedDate,
				model.FinishedGoodsFlag,
				model.ListPrice,
				model.MakeFlag,
				model.ModifiedDate,
				model.Name,
				model.ProductLine,
				model.ProductModelID,
				model.ProductNumber,
				model.ProductSubcategoryID,
				model.ReorderPoint,
				model.Rowguid,
				model.SafetyStockLevel,
				model.SellEndDate,
				model.SellStartDate,
				model.Size,
				model.SizeUnitMeasureCode,
				model.StandardCost,
				model.Style,
				model.Weight,
				model.WeightUnitMeasureCode);
			return boProduct;
		}

		public virtual ApiProductServerResponseModel MapBOToModel(
			BOProduct boProduct)
		{
			var model = new ApiProductServerResponseModel();

			model.SetProperties(boProduct.ProductID, boProduct.@Class, boProduct.Color, boProduct.DaysToManufacture, boProduct.DiscontinuedDate, boProduct.FinishedGoodsFlag, boProduct.ListPrice, boProduct.MakeFlag, boProduct.ModifiedDate, boProduct.Name, boProduct.ProductLine, boProduct.ProductModelID, boProduct.ProductNumber, boProduct.ProductSubcategoryID, boProduct.ReorderPoint, boProduct.Rowguid, boProduct.SafetyStockLevel, boProduct.SellEndDate, boProduct.SellStartDate, boProduct.Size, boProduct.SizeUnitMeasureCode, boProduct.StandardCost, boProduct.Style, boProduct.Weight, boProduct.WeightUnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductServerResponseModel> MapBOToModel(
			List<BOProduct> items)
		{
			List<ApiProductServerResponseModel> response = new List<ApiProductServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a87898c8711558d2bc939a8bcf6bd549</Hash>
</Codenesium>*/