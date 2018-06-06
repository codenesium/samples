using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

			model.SetProperties(boTransactionHistoryArchive.ActualCost, boTransactionHistoryArchive.ModifiedDate, boTransactionHistoryArchive.ProductID, boTransactionHistoryArchive.Quantity, boTransactionHistoryArchive.ReferenceOrderID, boTransactionHistoryArchive.ReferenceOrderLineID, boTransactionHistoryArchive.TransactionDate, boTransactionHistoryArchive.TransactionID, boTransactionHistoryArchive.TransactionType);

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
    <Hash>4afbff3af9036571157a49cbdc9e9416</Hash>
</Codenesium>*/