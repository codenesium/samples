using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALTransactionHistoryMapper
	{
		public virtual TransactionHistory MapModelToEntity(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model
			)
		{
			TransactionHistory item = new TransactionHistory();
			item.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return item;
		}

		public virtual ApiTransactionHistoryServerResponseModel MapEntityToModel(
			TransactionHistory item)
		{
			var model = new ApiTransactionHistoryServerResponseModel();

			model.SetProperties(item.TransactionID,
			                    item.ActualCost,
			                    item.ModifiedDate,
			                    item.ProductID,
			                    item.Quantity,
			                    item.ReferenceOrderID,
			                    item.ReferenceOrderLineID,
			                    item.TransactionDate,
			                    item.TransactionType);
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

			return model;
		}

		public virtual List<ApiTransactionHistoryServerResponseModel> MapEntityToModel(
			List<TransactionHistory> items)
		{
			List<ApiTransactionHistoryServerResponseModel> response = new List<ApiTransactionHistoryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>915b80e00dbb18eb067d9efcba5e27cf</Hash>
</Codenesium>*/