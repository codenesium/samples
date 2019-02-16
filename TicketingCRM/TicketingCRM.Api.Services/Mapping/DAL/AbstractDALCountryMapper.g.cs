using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALCountryMapper
	{
		public virtual Country MapModelToEntity(
			int id,
			ApiCountryServerRequestModel model
			)
		{
			Country item = new Country();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCountryServerResponseModel MapEntityToModel(
			Country item)
		{
			var model = new ApiCountryServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCountryServerResponseModel> MapEntityToModel(
			List<Country> items)
		{
			List<ApiCountryServerResponseModel> response = new List<ApiCountryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>408e865d3a32159017747d7ae4dc10d5</Hash>
</Codenesium>*/