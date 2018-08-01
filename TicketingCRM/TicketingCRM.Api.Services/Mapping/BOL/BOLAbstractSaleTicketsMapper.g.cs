using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractSaleTicketsMapper
	{
		public virtual BOSaleTickets MapModelToBO(
			int id,
			ApiSaleTicketsRequestModel model
			)
		{
			BOSaleTickets boSaleTickets = new BOSaleTickets();
			boSaleTickets.SetProperties(
				id,
				model.SaleId,
				model.TicketId);
			return boSaleTickets;
		}

		public virtual ApiSaleTicketsResponseModel MapBOToModel(
			BOSaleTickets boSaleTickets)
		{
			var model = new ApiSaleTicketsResponseModel();

			model.SetProperties(boSaleTickets.Id, boSaleTickets.SaleId, boSaleTickets.TicketId);

			return model;
		}

		public virtual List<ApiSaleTicketsResponseModel> MapBOToModel(
			List<BOSaleTickets> items)
		{
			List<ApiSaleTicketsResponseModel> response = new List<ApiSaleTicketsResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e10433e224a97f1f44df65c32541075e</Hash>
</Codenesium>*/