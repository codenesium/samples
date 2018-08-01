using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTransactionMapper
	{
		public virtual BOTransaction MapModelToBO(
			int id,
			ApiTransactionRequestModel model
			)
		{
			BOTransaction boTransaction = new BOTransaction();
			boTransaction.SetProperties(
				id,
				model.Amount,
				model.GatewayConfirmationNumber,
				model.TransactionStatusId);
			return boTransaction;
		}

		public virtual ApiTransactionResponseModel MapBOToModel(
			BOTransaction boTransaction)
		{
			var model = new ApiTransactionResponseModel();

			model.SetProperties(boTransaction.Id, boTransaction.Amount, boTransaction.GatewayConfirmationNumber, boTransaction.TransactionStatusId);

			return model;
		}

		public virtual List<ApiTransactionResponseModel> MapBOToModel(
			List<BOTransaction> items)
		{
			List<ApiTransactionResponseModel> response = new List<ApiTransactionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>75b8d0395985cd462d2cabe417584332</Hash>
</Codenesium>*/