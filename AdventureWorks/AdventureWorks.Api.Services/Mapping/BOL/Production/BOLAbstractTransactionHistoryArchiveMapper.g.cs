using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractTransactionHistoryArchiveMapper
	{
		public virtual BOTransactionHistoryArchive MapModelToBO(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model
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

		public virtual ApiTransactionHistoryArchiveResponseModel MapBOToModel(
			BOTransactionHistoryArchive boTransactionHistoryArchive)
		{
			var model = new ApiTransactionHistoryArchiveResponseModel();

			model.SetProperties(boTransactionHistoryArchive.TransactionID, boTransactionHistoryArchive.ActualCost, boTransactionHistoryArchive.ModifiedDate, boTransactionHistoryArchive.ProductID, boTransactionHistoryArchive.Quantity, boTransactionHistoryArchive.ReferenceOrderID, boTransactionHistoryArchive.ReferenceOrderLineID, boTransactionHistoryArchive.TransactionDate, boTransactionHistoryArchive.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryArchiveResponseModel> MapBOToModel(
			List<BOTransactionHistoryArchive> items)
		{
			List<ApiTransactionHistoryArchiveResponseModel> response = new List<ApiTransactionHistoryArchiveResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>317c647c28b8dc3a40aff68fb9ce98c7</Hash>
</Codenesium>*/