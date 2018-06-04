using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductMapper
	{
		public virtual BOProduct MapModelToBO(
			int productID,
			ApiProductRequestModel model
			)
		{
			BOProduct BOProduct = new BOProduct();

			BOProduct.SetProperties(
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
			return BOProduct;
		}

		public virtual ApiProductResponseModel MapBOToModel(
			BOProduct BOProduct)
		{
			if (BOProduct == null)
			{
				return null;
			}

			var model = new ApiProductResponseModel();

			model.SetProperties(BOProduct.@Class, BOProduct.Color, BOProduct.DaysToManufacture, BOProduct.DiscontinuedDate, BOProduct.FinishedGoodsFlag, BOProduct.ListPrice, BOProduct.MakeFlag, BOProduct.ModifiedDate, BOProduct.Name, BOProduct.ProductID, BOProduct.ProductLine, BOProduct.ProductModelID, BOProduct.ProductNumber, BOProduct.ProductSubcategoryID, BOProduct.ReorderPoint, BOProduct.Rowguid, BOProduct.SafetyStockLevel, BOProduct.SellEndDate, BOProduct.SellStartDate, BOProduct.Size, BOProduct.SizeUnitMeasureCode, BOProduct.StandardCost, BOProduct.Style, BOProduct.Weight, BOProduct.WeightUnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductResponseModel> MapBOToModel(
			List<BOProduct> BOs)
		{
			List<ApiProductResponseModel> response = new List<ApiProductResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1f55e47b34a6c68b0668145788549f5c</Hash>
</Codenesium>*/