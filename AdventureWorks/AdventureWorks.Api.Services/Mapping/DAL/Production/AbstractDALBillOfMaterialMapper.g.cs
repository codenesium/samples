using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBillOfMaterialMapper
	{
		public virtual BillOfMaterial MapModelToEntity(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model
			)
		{
			BillOfMaterial item = new BillOfMaterial();
			item.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
			return item;
		}

		public virtual ApiBillOfMaterialServerResponseModel MapEntityToModel(
			BillOfMaterial item)
		{
			var model = new ApiBillOfMaterialServerResponseModel();

			model.SetProperties(item.BillOfMaterialsID,
			                    item.BOMLevel,
			                    item.ComponentID,
			                    item.EndDate,
			                    item.ModifiedDate,
			                    item.PerAssemblyQty,
			                    item.ProductAssemblyID,
			                    item.StartDate,
			                    item.UnitMeasureCode);
			if (item.ComponentIDNavigation != null)
			{
				var componentIDModel = new ApiProductServerResponseModel();
				componentIDModel.SetProperties(
					item.ComponentIDNavigation.ProductID,
					item.ComponentIDNavigation.Color,
					item.ComponentIDNavigation.DaysToManufacture,
					item.ComponentIDNavigation.DiscontinuedDate,
					item.ComponentIDNavigation.FinishedGoodsFlag,
					item.ComponentIDNavigation.ListPrice,
					item.ComponentIDNavigation.MakeFlag,
					item.ComponentIDNavigation.ModifiedDate,
					item.ComponentIDNavigation.Name,
					item.ComponentIDNavigation.ProductLine,
					item.ComponentIDNavigation.ProductModelID,
					item.ComponentIDNavigation.ProductNumber,
					item.ComponentIDNavigation.ProductSubcategoryID,
					item.ComponentIDNavigation.ReorderPoint,
					item.ComponentIDNavigation.ReservedClass,
					item.ComponentIDNavigation.Rowguid,
					item.ComponentIDNavigation.SafetyStockLevel,
					item.ComponentIDNavigation.SellEndDate,
					item.ComponentIDNavigation.SellStartDate,
					item.ComponentIDNavigation.Size,
					item.ComponentIDNavigation.SizeUnitMeasureCode,
					item.ComponentIDNavigation.StandardCost,
					item.ComponentIDNavigation.Style,
					item.ComponentIDNavigation.Weight,
					item.ComponentIDNavigation.WeightUnitMeasureCode);

				model.SetComponentIDNavigation(componentIDModel);
			}

			if (item.ProductAssemblyIDNavigation != null)
			{
				var productAssemblyIDModel = new ApiProductServerResponseModel();
				productAssemblyIDModel.SetProperties(
					item.ProductAssemblyIDNavigation.ProductID,
					item.ProductAssemblyIDNavigation.Color,
					item.ProductAssemblyIDNavigation.DaysToManufacture,
					item.ProductAssemblyIDNavigation.DiscontinuedDate,
					item.ProductAssemblyIDNavigation.FinishedGoodsFlag,
					item.ProductAssemblyIDNavigation.ListPrice,
					item.ProductAssemblyIDNavigation.MakeFlag,
					item.ProductAssemblyIDNavigation.ModifiedDate,
					item.ProductAssemblyIDNavigation.Name,
					item.ProductAssemblyIDNavigation.ProductLine,
					item.ProductAssemblyIDNavigation.ProductModelID,
					item.ProductAssemblyIDNavigation.ProductNumber,
					item.ProductAssemblyIDNavigation.ProductSubcategoryID,
					item.ProductAssemblyIDNavigation.ReorderPoint,
					item.ProductAssemblyIDNavigation.ReservedClass,
					item.ProductAssemblyIDNavigation.Rowguid,
					item.ProductAssemblyIDNavigation.SafetyStockLevel,
					item.ProductAssemblyIDNavigation.SellEndDate,
					item.ProductAssemblyIDNavigation.SellStartDate,
					item.ProductAssemblyIDNavigation.Size,
					item.ProductAssemblyIDNavigation.SizeUnitMeasureCode,
					item.ProductAssemblyIDNavigation.StandardCost,
					item.ProductAssemblyIDNavigation.Style,
					item.ProductAssemblyIDNavigation.Weight,
					item.ProductAssemblyIDNavigation.WeightUnitMeasureCode);

				model.SetProductAssemblyIDNavigation(productAssemblyIDModel);
			}

			if (item.UnitMeasureCodeNavigation != null)
			{
				var unitMeasureCodeModel = new ApiUnitMeasureServerResponseModel();
				unitMeasureCodeModel.SetProperties(
					item.UnitMeasureCodeNavigation.UnitMeasureCode,
					item.UnitMeasureCodeNavigation.ModifiedDate,
					item.UnitMeasureCodeNavigation.Name);

				model.SetUnitMeasureCodeNavigation(unitMeasureCodeModel);
			}

			return model;
		}

		public virtual List<ApiBillOfMaterialServerResponseModel> MapEntityToModel(
			List<BillOfMaterial> items)
		{
			List<ApiBillOfMaterialServerResponseModel> response = new List<ApiBillOfMaterialServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87a139722b9ec96f011a98f5f1cb1797</Hash>
</Codenesium>*/