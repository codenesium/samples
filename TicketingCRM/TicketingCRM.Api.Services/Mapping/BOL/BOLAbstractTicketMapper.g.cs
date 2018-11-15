using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractTicketMapper
	{
		public virtual BOTicket MapModelToBO(
			int id,
			ApiTicketServerRequestModel model
			)
		{
			BOTicket boTicket = new BOTicket();
			boTicket.SetProperties(
				id,
				model.PublicId,
				model.TicketStatusId);
			return boTicket;
		}

		public virtual ApiTicketServerResponseModel MapBOToModel(
			BOTicket boTicket)
		{
			var model = new ApiTicketServerResponseModel();

			model.SetProperties(boTicket.Id, boTicket.PublicId, boTicket.TicketStatusId);

			return model;
		}

		public virtual List<ApiTicketServerResponseModel> MapBOToModel(
			List<BOTicket> items)
		{
			List<ApiTicketServerResponseModel> response = new List<ApiTicketServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8e203beacec226ed42ce39d0f61dbdfd</Hash>
</Codenesium>*/