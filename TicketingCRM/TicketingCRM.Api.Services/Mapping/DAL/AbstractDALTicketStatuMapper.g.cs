using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTicketStatuMapper
	{
		public virtual TicketStatu MapModelToEntity(
			int id,
			ApiTicketStatuServerRequestModel model
			)
		{
			TicketStatu item = new TicketStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTicketStatuServerResponseModel MapEntityToModel(
			TicketStatu item)
		{
			var model = new ApiTicketStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTicketStatuServerResponseModel> MapEntityToModel(
			List<TicketStatu> items)
		{
			List<ApiTicketStatuServerResponseModel> response = new List<ApiTicketStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d6d8879b91a8b241e67bfa6a202e13a5</Hash>
</Codenesium>*/