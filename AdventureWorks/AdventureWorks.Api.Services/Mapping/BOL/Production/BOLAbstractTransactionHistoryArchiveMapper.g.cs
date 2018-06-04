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
			BOTransactionHistoryArchive BOTransactionHistoryArchive = new BOTransactionHistoryArchive();

			BOTransactionHistoryArchive.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return BOTransactionHistoryArchive;
		}

		public virtual ApiTransactionHistoryArchiveResponseModel MapBOToModel(
			BOTransactionHistoryArchive BOTransactionHistoryArchive)
		{
			if (BOTransactionHistoryArchive == null)
			{
				return null;
			}

			var model = new ApiTransactionHistoryArchiveResponseModel();

			model.SetProperties(BOTransactionHistoryArchive.ActualCost, BOTransactionHistoryArchive.ModifiedDate, BOTransactionHistoryArchive.ProductID, BOTransactionHistoryArchive.Quantity, BOTransactionHistoryArchive.ReferenceOrderID, BOTransactionHistoryArchive.ReferenceOrderLineID, BOTransactionHistoryArchive.TransactionDate, BOTransactionHistoryArchive.TransactionID, BOTransactionHistoryArchive.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryArchiveResponseModel> MapBOToModel(
			List<BOTransactionHistoryArchive> BOs)
		{
			List<ApiTransactionHistoryArchiveResponseModel> response = new List<ApiTransactionHistoryArchiveResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bafe84ffc2896180aed9e41b54618b16</Hash>
</Codenesium>*/