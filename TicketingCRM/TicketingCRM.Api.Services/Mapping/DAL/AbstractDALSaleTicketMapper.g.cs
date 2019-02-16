using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALSaleTicketMapper
	{
		public virtual SaleTicket MapModelToEntity(
			int id,
			ApiSaleTicketServerRequestModel model
			)
		{
			SaleTicket item = new SaleTicket();
			item.SetProperties(
				id,
				model.SaleId,
				model.TicketId);
			return item;
		}

		public virtual ApiSaleTicketServerResponseModel MapEntityToModel(
			SaleTicket item)
		{
			var model = new ApiSaleTicketServerResponseModel();

			model.SetProperties(item.Id,
			                    item.SaleId,
			                    item.TicketId);
			if (item.SaleIdNavigation != null)
			{
				var saleIdModel = new ApiSaleServerResponseModel();
				saleIdModel.SetProperties(
					item.Id,
					item.SaleIdNavigation.IpAddress,
					item.SaleIdNavigation.Note,
					item.SaleIdNavigation.SaleDate,
					item.SaleIdNavigation.TransactionId);

				model.SetSaleIdNavigation(saleIdModel);
			}

			if (item.TicketIdNavigation != null)
			{
				var ticketIdModel = new ApiTicketServerResponseModel();
				ticketIdModel.SetProperties(
					item.Id,
					item.TicketIdNavigation.PublicId,
					item.TicketIdNavigation.TicketStatusId);

				model.SetTicketIdNavigation(ticketIdModel);
			}

			return model;
		}

		public virtual List<ApiSaleTicketServerResponseModel> MapEntityToModel(
			List<SaleTicket> items)
		{
			List<ApiSaleTicketServerResponseModel> response = new List<ApiSaleTicketServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>32121a9087cea28af928a36222477b5f</Hash>
</Codenesium>*/