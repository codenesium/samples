using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALTransactionHistoryArchiveMapper
	{
		public virtual TransactionHistoryArchive MapModelToEntity(
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

		public virtual ApiTransactionHistoryArchiveServerResponseModel MapEntityToModel(
			TransactionHistoryArchive item)
		{
			var model = new ApiTransactionHistoryArchiveServerResponseModel();

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

		public virtual List<ApiTransactionHistoryArchiveServerResponseModel> MapEntityToModel(
			List<TransactionHistoryArchive> items)
		{
			List<ApiTransactionHistoryArchiveServerResponseModel> response = new List<ApiTransactionHistoryArchiveServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2b0566515e7396967d533ab18c710111</Hash>
</Codenesium>*/