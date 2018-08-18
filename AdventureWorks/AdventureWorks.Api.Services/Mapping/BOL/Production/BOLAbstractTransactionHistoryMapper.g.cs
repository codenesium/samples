using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractTransactionHistoryMapper
	{
		public virtual BOTransactionHistory MapModelToBO(
			int transactionID,
			ApiTransactionHistoryRequestModel model
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

		public virtual ApiTransactionHistoryResponseModel MapBOToModel(
			BOTransactionHistory boTransactionHistory)
		{
			var model = new ApiTransactionHistoryResponseModel();

			model.SetProperties(boTransactionHistory.TransactionID, boTransactionHistory.ActualCost, boTransactionHistory.ModifiedDate, boTransactionHistory.ProductID, boTransactionHistory.Quantity, boTransactionHistory.ReferenceOrderID, boTransactionHistory.ReferenceOrderLineID, boTransactionHistory.TransactionDate, boTransactionHistory.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryResponseModel> MapBOToModel(
			List<BOTransactionHistory> items)
		{
			List<ApiTransactionHistoryResponseModel> response = new List<ApiTransactionHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ec13b2f4143be20aec3aed980a7d6c9a</Hash>
</Codenesium>*/