using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALCountryMapper : IDALCountryMapper
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
    <Hash>db02ee63afed402c5acfc6106897c41f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/