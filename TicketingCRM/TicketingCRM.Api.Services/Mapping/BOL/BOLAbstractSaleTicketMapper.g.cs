using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractSaleTicketMapper
	{
		public virtual BOSaleTicket MapModelToBO(
			int id,
			ApiSaleTicketRequestModel model
			)
		{
			BOSaleTicket boSaleTicket = new BOSaleTicket();
			boSaleTicket.SetProperties(
				id,
				model.SaleId,
				model.TicketId);
			return boSaleTicket;
		}

		public virtual ApiSaleTicketResponseModel MapBOToModel(
			BOSaleTicket boSaleTicket)
		{
			var model = new ApiSaleTicketResponseModel();

			model.SetProperties(boSaleTicket.Id, boSaleTicket.SaleId, boSaleTicket.TicketId);

			return model;
		}

		public virtual List<ApiSaleTicketResponseModel> MapBOToModel(
			List<BOSaleTicket> items)
		{
			List<ApiSaleTicketResponseModel> response = new List<ApiSaleTicketResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>008608b396863799ce98139656520616</Hash>
</Codenesium>*/