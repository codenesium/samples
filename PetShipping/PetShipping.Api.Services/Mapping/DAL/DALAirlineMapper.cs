using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALAirlineMapper : IDALAirlineMapper
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
    <Hash>1fe8dc47589d929e59302974300fe0e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/