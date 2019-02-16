using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>5658d3997507ec895ca905c6d9620658</Hash>
</Codenesium>*/