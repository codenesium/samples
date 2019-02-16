using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTicketMapper
	{
		public virtual Ticket MapModelToEntity(
			int id,
			ApiTicketServerRequestModel model
			)
		{
			Ticket item = new Ticket();
			item.SetProperties(
				id,
				model.PublicId,
				model.TicketStatusId);
			return item;
		}

		public virtual ApiTicketServerResponseModel MapEntityToModel(
			Ticket item)
		{
			var model = new ApiTicketServerResponseModel();

			model.SetProperties(item.Id,
			                    item.PublicId,
			                    item.TicketStatusId);
			if (item.TicketStatusIdNavigation != null)
			{
				var ticketStatusIdModel = new ApiTicketStatuServerResponseModel();
				ticketStatusIdModel.SetProperties(
					item.Id,
					item.TicketStatusIdNavigation.Name);

				model.SetTicketStatusIdNavigation(ticketStatusIdModel);
			}

			return model;
		}

		public virtual List<ApiTicketServerResponseModel> MapEntityToModel(
			List<Ticket> items)
		{
			List<ApiTicketServerResponseModel> response = new List<ApiTicketServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21269f4d14d0d734cf86ac26b2a34aaf</Hash>
</Codenesium>*/