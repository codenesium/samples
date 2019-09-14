using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALTicketStatusMapper : IDALTicketStatusMapper
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
    <Hash>5af2c8bc88f9aeddfdb8a2b4b8fc2118</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/