using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTransactionHistoryMapper
	{
		public virtual DTOTransactionHistory MapModelToDTO(
			int transactionID,
			ApiTransactionHistoryRequestModel model
			)
		{
			DTOTransactionHistory dtoTransactionHistory = new DTOTransactionHistory();

			dtoTransactionHistory.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
			return dtoTransactionHistory;
		}

		public virtual ApiTransactionHistoryResponseModel MapDTOToModel(
			DTOTransactionHistory dtoTransactionHistory)
		{
			if (dtoTransactionHistory == null)
			{
				return null;
			}

			var model = new ApiTransactionHistoryResponseModel();

			model.SetProperties(dtoTransactionHistory.ActualCost, dtoTransactionHistory.ModifiedDate, dtoTransactionHistory.ProductID, dtoTransactionHistory.Quantity, dtoTransactionHistory.ReferenceOrderID, dtoTransactionHistory.ReferenceOrderLineID, dtoTransactionHistory.TransactionDate, dtoTransactionHistory.TransactionID, dtoTransactionHistory.TransactionType);

			return model;
		}

		public virtual List<ApiTransactionHistoryResponseModel> MapDTOToModel(
			List<DTOTransactionHistory> dtos)
		{
			List<ApiTransactionHistoryResponseModel> response = new List<ApiTransactionHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>07cbc26fa7326fce52c01cb0148e1140</Hash>
</Codenesium>*/