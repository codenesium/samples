using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALWorkOrderMapper
	{
		public virtual WorkOrder MapModelToEntity(
			int workOrderID,
			ApiWorkOrderServerRequestModel model
			)
		{
			WorkOrder item = new WorkOrder();
			item.SetProperties(
				workOrderID,
				model.DueDate,
				model.EndDate,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.ScrappedQty,
				model.ScrapReasonID,
				model.StartDate,
				model.StockedQty);
			return item;
		}

		public virtual ApiWorkOrderServerResponseModel MapEntityToModel(
			WorkOrder item)
		{
			var model = new ApiWorkOrderServerResponseModel();

			model.SetProperties(item.WorkOrderID,
			                    item.DueDate,
			                    item.EndDate,
			                    item.ModifiedDate,
			                    item.OrderQty,
			                    item.ProductID,
			                    item.ScrappedQty,
			                    item.ScrapReasonID,
			                    item.StartDate,
			                    item.StockedQty);
			if (item.ProductIDNavigation != null)
			{
				var productIDModel = new ApiProductServerResponseModel();
				productIDModel.SetProperties(
					item.ProductIDNavigation.ProductID,
					item.ProductIDNavigation.Color,
					item.ProductIDNavigation.DaysToManufacture,
					item.ProductIDNavigation.DiscontinuedDate,
					item.ProductIDNavigation.FinishedGoodsFlag,
					item.ProductIDNavigation.ListPrice,
					item.ProductIDNavigation.MakeFlag,
					item.ProductIDNavigation.ModifiedDate,
					item.ProductIDNavigation.Name,
					item.ProductIDNavigation.ProductLine,
					item.ProductIDNavigation.ProductModelID,
					item.ProductIDNavigation.ProductNumber,
					item.ProductIDNavigation.ProductSubcategoryID,
					item.ProductIDNavigation.ReorderPoint,
					item.ProductIDNavigation.ReservedClass,
					item.ProductIDNavigation.Rowguid,
					item.ProductIDNavigation.SafetyStockLevel,
					item.ProductIDNavigation.SellEndDate,
					item.ProductIDNavigation.SellStartDate,
					item.ProductIDNavigation.Size,
					item.ProductIDNavigation.SizeUnitMeasureCode,
					item.ProductIDNavigation.StandardCost,
					item.ProductIDNavigation.Style,
					item.ProductIDNavigation.Weight,
					item.ProductIDNavigation.WeightUnitMeasureCode);

				model.SetProductIDNavigation(productIDModel);
			}

			if (item.ScrapReasonIDNavigation != null)
			{
				var scrapReasonIDModel = new ApiScrapReasonServerResponseModel();
				scrapReasonIDModel.SetProperties(
					item.ScrapReasonIDNavigation.ScrapReasonID,
					item.ScrapReasonIDNavigation.ModifiedDate,
					item.ScrapReasonIDNavigation.Name);

				model.SetScrapReasonIDNavigation(scrapReasonIDModel);
			}

			return model;
		}

		public virtual List<ApiWorkOrderServerResponseModel> MapEntityToModel(
			List<WorkOrder> items)
		{
			List<ApiWorkOrderServerResponseModel> response = new List<ApiWorkOrderServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>99af08239b897d7724c59260c73bc0f6</Hash>
</Codenesium>*/