using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALSaleMapper
	{
		public virtual Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model
			)
		{
			Sale item = new Sale();
			item.SetProperties(
				id,
				model.IpAddress,
				model.Notes,
				model.SaleDate,
				model.TransactionId);
			return item;
		}

		public virtual ApiSaleServerResponseModel MapEntityToModel(
			Sale item)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(item.Id,
			                    item.IpAddress,
			                    item.Notes,
			                    item.SaleDate,
			                    item.TransactionId);
			if (item.TransactionIdNavigation != null)
			{
				var transactionIdModel = new ApiTransactionServerResponseModel();
				transactionIdModel.SetProperties(
					item.TransactionIdNavigation.Id,
					item.TransactionIdNavigation.Amount,
					item.TransactionIdNavigation.GatewayConfirmationNumber,
					item.TransactionIdNavigation.TransactionStatusId);

				model.SetTransactionIdNavigation(transactionIdModel);
			}

			return model;
		}

		public virtual List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items)
		{
			List<ApiSaleServerResponseModel> response = new List<ApiSaleServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e2ce96c56a87da2093fe2266cf482178</Hash>
</Codenesium>*/