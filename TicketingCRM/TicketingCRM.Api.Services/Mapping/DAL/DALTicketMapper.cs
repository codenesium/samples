using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALTicketMapper : IDALTicketMapper
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
				var ticketStatusIdModel = new ApiTicketStatusServerResponseModel();
				ticketStatusIdModel.SetProperties(
					item.TicketStatusIdNavigation.Id,
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
    <Hash>ed2edf37ab47774861bfb21e2b898b6a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/