using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractTransactionHistoryMapper
	{
		public virtual BOTransactionHistory MapModelToBO(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model
			)
		{
			BOTransactionHistory boTransactionHistory = new BOTransactionHistory();
			boTransactionHistory.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return boTransactionHistory;
		}

		public virtual ApiTransactionHistoryServerResponseModel MapBOToModel(
			BOTransactionHistory boTransactionHistory)
		{
			var model = new ApiTransactionHistoryServerResponseModel();

			model.SetProperties(boTransactionHistory.TransactionID, boTransactionHistory.ActualCost, boTransactionHistory.ModifiedDate, boTransactionHistory.ProductID, boTransactionHistory.Quantity, boTransactionHistory.ReferenceOrderID, boTransactionHistory.ReferenceOrderLineID, boTransactionHistory.TransactionDate, boTransactionHistory.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryServerResponseModel> MapBOToModel(
			List<BOTransactionHistory> items)
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
    <Hash>54812d211d20b7c26c2a4cff3cb9f512</Hash>
</Codenesium>*/