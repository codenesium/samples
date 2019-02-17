using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTransactionMapper
	{
		public virtual Transaction MapModelToEntity(
			int id,
			ApiTransactionServerRequestModel model
			)
		{
			Transaction item = new Transaction();
			item.SetProperties(
				id,
				model.Amount,
				model.GatewayConfirmationNumber,
				model.TransactionStatusId);
			return item;
		}

		public virtual ApiTransactionServerResponseModel MapEntityToModel(
			Transaction item)
		{
			var model = new ApiTransactionServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Amount,
			                    item.GatewayConfirmationNumber,
			                    item.TransactionStatusId);
			if (item.TransactionStatusIdNavigation != null)
			{
				var transactionStatusIdModel = new ApiTransactionStatuServerResponseModel();
				transactionStatusIdModel.SetProperties(
					item.TransactionStatusIdNavigation.Id,
					item.TransactionStatusIdNavigation.Name);

				model.SetTransactionStatusIdNavigation(transactionStatusIdModel);
			}

			return model;
		}

		public virtual List<ApiTransactionServerResponseModel> MapEntityToModel(
			List<Transaction> items)
		{
			List<ApiTransactionServerResponseModel> response = new List<ApiTransactionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f354052d9094354b1024c66cdcac7bd7</Hash>
</Codenesium>*/