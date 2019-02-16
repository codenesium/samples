using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductMapper
	{
		public virtual Product MapModelToBO(
			int productID,
			ApiProductServerRequestModel model
			)
		{
			Product item = new Product();
			item.SetProperties(
				productID,
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
			return item;
		}

		public virtual ApiProductServerResponseModel MapBOToModel(
			Product item)
		{
			var model = new ApiProductServerResponseModel();

			model.SetProperties(item.ProductID, item.Color, item.DaysToManufacture, item.DiscontinuedDate, item.FinishedGoodsFlag, item.ListPrice, item.MakeFlag, item.ModifiedDate, item.Name, item.ProductLine, item.ProductModelID, item.ProductNumber, item.ProductSubcategoryID, item.ReorderPoint, item.Rowguid, item.SafetyStockLevel, item.SellEndDate, item.SellStartDate, item.Size, item.SizeUnitMeasureCode, item.StandardCost, item.Style, item.Weight, item.WeightUnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductServerResponseModel> MapBOToModel(
			List<Product> items)
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
    <Hash>4f4fe289f195d77eadf58c93a7b872c2</Hash>
</Codenesium>*/