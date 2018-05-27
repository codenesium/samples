using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTransactionHistoryArchiveMapper
	{
		public virtual DTOTransactionHistoryArchive MapModelToDTO(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model
			)
		{
			DTOTransactionHistoryArchive dtoTransactionHistoryArchive = new DTOTransactionHistoryArchive();

			dtoTransactionHistoryArchive.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return dtoTransactionHistoryArchive;
		}

		public virtual ApiTransactionHistoryArchiveResponseModel MapDTOToModel(
			DTOTransactionHistoryArchive dtoTransactionHistoryArchive)
		{
			if (dtoTransactionHistoryArchive == null)
			{
				return null;
			}

			var model = new ApiTransactionHistoryArchiveResponseModel();

			model.SetProperties(dtoTransactionHistoryArchive.ActualCost, dtoTransactionHistoryArchive.ModifiedDate, dtoTransactionHistoryArchive.ProductID, dtoTransactionHistoryArchive.Quantity, dtoTransactionHistoryArchive.ReferenceOrderID, dtoTransactionHistoryArchive.ReferenceOrderLineID, dtoTransactionHistoryArchive.TransactionDate, dtoTransactionHistoryArchive.TransactionID, dtoTransactionHistoryArchive.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryArchiveResponseModel> MapDTOToModel(
			List<DTOTransactionHistoryArchive> dtos)
		{
			List<ApiTransactionHistoryArchiveResponseModel> response = new List<ApiTransactionHistoryArchiveResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6ac7e1893b1d52fa8d4493e32e002b21</Hash>
</Codenesium>*/