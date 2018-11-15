using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTransactionMapper
	{
		public virtual BOTransaction MapModelToBO(
			int id,
			ApiTransactionServerRequestModel model
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

		public virtual ApiTransactionServerResponseModel MapBOToModel(
			BOTransaction boTransaction)
		{
			var model = new ApiTransactionServerResponseModel();

			model.SetProperties(boTransaction.Id, boTransaction.Amount, boTransaction.GatewayConfirmationNumber, boTransaction.TransactionStatusId);

			return model;
		}

		public virtual List<ApiTransactionServerResponseModel> MapBOToModel(
			List<BOTransaction> items)
		{
			List<ApiTransactionServerResponseModel> response = new List<ApiTransactionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3e7d14611304002cf9af99e2ac1a6d5d</Hash>
</Codenesium>*/