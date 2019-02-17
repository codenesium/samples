using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALTicketStatusMapper
	{
		public virtual TicketStatus MapModelToEntity(
			int id,
			ApiTicketStatusServerRequestModel model
			)
		{
			TicketStatus item = new TicketStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTicketStatusServerResponseModel MapEntityToModel(
			TicketStatus item)
		{
			var model = new ApiTicketStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTicketStatusServerResponseModel> MapEntityToModel(
			List<TicketStatus> items)
		{
			List<ApiTicketStatusServerResponseModel> response = new List<ApiTicketStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5a29dcc51fbedcd9ca90b7e32c516f23</Hash>
</Codenesium>*/