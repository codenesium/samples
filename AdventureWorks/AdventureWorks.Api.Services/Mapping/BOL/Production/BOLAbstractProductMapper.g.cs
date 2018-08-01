using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductMapper
	{
		public virtual BOProduct MapModelToBO(
			int productID,
			ApiProductRequestModel model
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

		public virtual ApiProductResponseModel MapBOToModel(
			BOProduct boProduct)
		{
			var model = new ApiProductResponseModel();

			model.SetProperties(boProduct.ProductID, boProduct.@Class, boProduct.Color, boProduct.DaysToManufacture, boProduct.DiscontinuedDate, boProduct.FinishedGoodsFlag, boProduct.ListPrice, boProduct.MakeFlag, boProduct.ModifiedDate, boProduct.Name, boProduct.ProductLine, boProduct.ProductModelID, boProduct.ProductNumber, boProduct.ProductSubcategoryID, boProduct.ReorderPoint, boProduct.Rowguid, boProduct.SafetyStockLevel, boProduct.SellEndDate, boProduct.SellStartDate, boProduct.Size, boProduct.SizeUnitMeasureCode, boProduct.StandardCost, boProduct.Style, boProduct.Weight, boProduct.WeightUnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductResponseModel> MapBOToModel(
			List<BOProduct> items)
		{
			List<ApiProductResponseModel> response = new List<ApiProductResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>153212983525a9bad12d942c2df57cbc</Hash>
</Codenesium>*/