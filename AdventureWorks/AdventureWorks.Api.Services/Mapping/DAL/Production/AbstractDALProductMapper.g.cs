using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductMapper
	{
		public virtual Product MapModelToEntity(
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
				model.ReservedClass,
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

		public virtual ApiProductServerResponseModel MapEntityToModel(
			Product item)
		{
			var model = new ApiProductServerResponseModel();

			model.SetProperties(item.ProductID,
			                    item.Color,
			                    item.DaysToManufacture,
			                    item.DiscontinuedDate,
			                    item.FinishedGoodsFlag,
			                    item.ListPrice,
			                    item.MakeFlag,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.ProductLine,
			                    item.ProductModelID,
			                    item.ProductNumber,
			                    item.ProductSubcategoryID,
			                    item.ReorderPoint,
			                    item.ReservedClass,
			                    item.Rowguid,
			                    item.SafetyStockLevel,
			                    item.SellEndDate,
			                    item.SellStartDate,
			                    item.Size,
			                    item.SizeUnitMeasureCode,
			                    item.StandardCost,
			                    item.Style,
			                    item.Weight,
			                    item.WeightUnitMeasureCode);
			if (item.ProductModelIDNavigation != null)
			{
				var productModelIDModel = new ApiProductModelServerResponseModel();
				productModelIDModel.SetProperties(
					item.ProductModelIDNavigation.ProductModelID,
					item.ProductModelIDNavigation.CatalogDescription,
					item.ProductModelIDNavigation.Instruction,
					item.ProductModelIDNavigation.ModifiedDate,
					item.ProductModelIDNavigation.Name,
					item.ProductModelIDNavigation.Rowguid);

				model.SetProductModelIDNavigation(productModelIDModel);
			}

			if (item.ProductSubcategoryIDNavigation != null)
			{
				var productSubcategoryIDModel = new ApiProductSubcategoryServerResponseModel();
				productSubcategoryIDModel.SetProperties(
					item.ProductSubcategoryIDNavigation.ProductSubcategoryID,
					item.ProductSubcategoryIDNavigation.ModifiedDate,
					item.ProductSubcategoryIDNavigation.Name,
					item.ProductSubcategoryIDNavigation.ProductCategoryID,
					item.ProductSubcategoryIDNavigation.Rowguid);

				model.SetProductSubcategoryIDNavigation(productSubcategoryIDModel);
			}

			if (item.SizeUnitMeasureCodeNavigation != null)
			{
				var sizeUnitMeasureCodeModel = new ApiUnitMeasureServerResponseModel();
				sizeUnitMeasureCodeModel.SetProperties(
					item.SizeUnitMeasureCodeNavigation.UnitMeasureCode,
					item.SizeUnitMeasureCodeNavigation.ModifiedDate,
					item.SizeUnitMeasureCodeNavigation.Name);

				model.SetSizeUnitMeasureCodeNavigation(sizeUnitMeasureCodeModel);
			}

			if (item.WeightUnitMeasureCodeNavigation != null)
			{
				var weightUnitMeasureCodeModel = new ApiUnitMeasureServerResponseModel();
				weightUnitMeasureCodeModel.SetProperties(
					item.WeightUnitMeasureCodeNavigation.UnitMeasureCode,
					item.WeightUnitMeasureCodeNavigation.ModifiedDate,
					item.WeightUnitMeasureCodeNavigation.Name);

				model.SetWeightUnitMeasureCodeNavigation(weightUnitMeasureCodeModel);
			}

			return model;
		}

		public virtual List<ApiProductServerResponseModel> MapEntityToModel(
			List<Product> items)
		{
			List<ApiProductServerResponseModel> response = new List<ApiProductServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d0f2a9509426c3b51277336c04895590</Hash>
</Codenesium>*/