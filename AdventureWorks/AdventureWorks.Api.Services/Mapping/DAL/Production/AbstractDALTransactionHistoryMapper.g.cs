using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALTransactionHistoryMapper
	{
		public virtual TransactionHistory MapModelToBO(
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

		public virtual ApiTransactionHistoryServerResponseModel MapBOToModel(
			TransactionHistory item)
		{
			var model = new ApiTransactionHistoryServerResponseModel();

			model.SetProperties(item.TransactionID, item.ActualCost, item.ModifiedDate, item.ProductID, item.Quantity, item.ReferenceOrderID, item.ReferenceOrderLineID, item.TransactionDate, item.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryServerResponseModel> MapBOToModel(
			List<TransactionHistory> items)
		{
			List<ApiTransactionHistoryServerResponseModel> response = new List<ApiTransactionHistoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e99769bec6c9faeb62cb1541b232f36e</Hash>
</Codenesium>*/