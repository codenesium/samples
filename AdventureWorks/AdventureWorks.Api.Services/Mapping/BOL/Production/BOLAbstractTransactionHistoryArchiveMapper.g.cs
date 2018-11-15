using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractTransactionHistoryArchiveMapper
	{
		public virtual BOTransactionHistoryArchive MapModelToBO(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel model
			)
		{
			BOTransactionHistoryArchive boTransactionHistoryArchive = new BOTransactionHistoryArchive();
			boTransactionHistoryArchive.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return boTransactionHistoryArchive;
		}

		public virtual ApiTransactionHistoryArchiveServerResponseModel MapBOToModel(
			BOTransactionHistoryArchive boTransactionHistoryArchive)
		{
			var model = new ApiTransactionHistoryArchiveServerResponseModel();

			model.SetProperties(boTransactionHistoryArchive.TransactionID, boTransactionHistoryArchive.ActualCost, boTransactionHistoryArchive.ModifiedDate, boTransactionHistoryArchive.ProductID, boTransactionHistoryArchive.Quantity, boTransactionHistoryArchive.ReferenceOrderID, boTransactionHistoryArchive.ReferenceOrderLineID, boTransactionHistoryArchive.TransactionDate, boTransactionHistoryArchive.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryArchiveServerResponseModel> MapBOToModel(
			List<BOTransactionHistoryArchive> items)
		{
			List<ApiTransactionHistoryArchiveServerResponseModel> response = new List<ApiTransactionHistoryArchiveServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>48f7929101babad5f1f5e95b2e363e61</Hash>
</Codenesium>*/