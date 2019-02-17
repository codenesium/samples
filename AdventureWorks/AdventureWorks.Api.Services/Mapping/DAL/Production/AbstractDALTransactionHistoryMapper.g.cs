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
    <Hash>d26df0da84f761d9bc46298958b3298d</Hash>
</Codenesium>*/