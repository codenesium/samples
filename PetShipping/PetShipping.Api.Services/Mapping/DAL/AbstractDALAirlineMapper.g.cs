using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALAirlineMapper
	{
		public virtual Airline MapModelToEntity(
			int id,
			ApiAirlineServerRequestModel model
			)
		{
			Airline item = new Airline();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiAirlineServerResponseModel MapEntityToModel(
			Airline item)
		{
			var model = new ApiAirlineServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiAirlineServerResponseModel> MapEntityToModel(
			List<Airline> items)
		{
			List<ApiAirlineServerResponseModel> response = new List<ApiAirlineServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3435212c8216f7cfec894d31eee090eb</Hash>
</Codenesium>*/