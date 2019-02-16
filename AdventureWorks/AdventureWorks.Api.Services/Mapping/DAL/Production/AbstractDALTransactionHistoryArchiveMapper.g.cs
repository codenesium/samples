using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALTransactionHistoryArchiveMapper
	{
		public virtual TransactionHistoryArchive MapModelToBO(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel model
			)
		{
			TransactionHistoryArchive item = new TransactionHistoryArchive();
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

		public virtual ApiTransactionHistoryArchiveServerResponseModel MapBOToModel(
			TransactionHistoryArchive item)
		{
			var model = new ApiTransactionHistoryArchiveServerResponseModel();

			model.SetProperties(item.TransactionID, item.ActualCost, item.ModifiedDate, item.ProductID, item.Quantity, item.ReferenceOrderID, item.ReferenceOrderLineID, item.TransactionDate, item.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryArchiveServerResponseModel> MapBOToModel(
			List<TransactionHistoryArchive> items)
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
    <Hash>85b1e064c71d98443f746c88138c35d2</Hash>
</Codenesium>*/