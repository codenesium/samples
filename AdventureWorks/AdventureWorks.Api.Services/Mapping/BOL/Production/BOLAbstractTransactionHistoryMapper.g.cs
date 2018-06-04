using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractTransactionHistoryMapper
	{
		public virtual BOTransactionHistory MapModelToBO(
			int transactionID,
			ApiTransactionHistoryRequestModel model
			)
		{
			BOTransactionHistory BOTransactionHistory = new BOTransactionHistory();

			BOTransactionHistory.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return BOTransactionHistory;
		}

		public virtual ApiTransactionHistoryResponseModel MapBOToModel(
			BOTransactionHistory BOTransactionHistory)
		{
			if (BOTransactionHistory == null)
			{
				return null;
			}

			var model = new ApiTransactionHistoryResponseModel();

			model.SetProperties(BOTransactionHistory.ActualCost, BOTransactionHistory.ModifiedDate, BOTransactionHistory.ProductID, BOTransactionHistory.Quantity, BOTransactionHistory.ReferenceOrderID, BOTransactionHistory.ReferenceOrderLineID, BOTransactionHistory.TransactionDate, BOTransactionHistory.TransactionID, BOTransactionHistory.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryResponseModel> MapBOToModel(
			List<BOTransactionHistory> BOs)
		{
			List<ApiTransactionHistoryResponseModel> response = new List<ApiTransactionHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b03b990c6bd09aac8de042cf3327d3c7</Hash>
</Codenesium>*/