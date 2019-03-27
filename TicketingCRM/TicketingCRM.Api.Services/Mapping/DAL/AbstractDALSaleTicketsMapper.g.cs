using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALSaleTicketsMapper
	{
		public virtual SaleTickets MapModelToEntity(
			int id,
			ApiSaleTicketsServerRequestModel model
			)
		{
			SaleTickets item = new SaleTickets();
			item.SetProperties(
				id,
				model.SaleId,
				model.TicketId);
			return item;
		}

		public virtual ApiSaleTicketsServerResponseModel MapEntityToModel(
			SaleTickets item)
		{
			var model = new ApiSaleTicketsServerResponseModel();

			model.SetProperties(item.Id,
			                    item.SaleId,
			                    item.TicketId);
			if (item.SaleIdNavigation != null)
			{
				var saleIdModel = new ApiSaleServerResponseModel();
				saleIdModel.SetProperties(
					item.SaleIdNavigation.Id,
					item.SaleIdNavigation.IpAddress,
					item.SaleIdNavigation.Notes,
					item.SaleIdNavigation.SaleDate,
					item.SaleIdNavigation.TransactionId);

				model.SetSaleIdNavigation(saleIdModel);
			}

			if (item.TicketIdNavigation != null)
			{
				var ticketIdModel = new ApiTicketServerResponseModel();
				ticketIdModel.SetProperties(
					item.TicketIdNavigation.Id,
					item.TicketIdNavigation.PublicId,
					item.TicketIdNavigation.TicketStatusId);

				model.SetTicketIdNavigation(ticketIdModel);
			}

			return model;
		}

		public virtual List<ApiSaleTicketsServerResponseModel> MapEntityToModel(
			List<SaleTickets> items)
		{
			List<ApiSaleTicketsServerResponseModel> response = new List<ApiSaleTicketsServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7b4632f42724a16570ca63ead00e9e3</Hash>
</Codenesium>*/