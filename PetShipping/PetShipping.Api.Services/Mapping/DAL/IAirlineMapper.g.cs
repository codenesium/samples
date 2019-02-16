using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALAirlineMapper
	{
		Airline MapModelToEntity(
			int id,
			ApiAirlineServerRequestModel model);

		ApiAirlineServerResponseModel MapEntityToModel(
			Airline item);

		List<ApiAirlineServerResponseModel> MapEntityToModel(
			List<Airline> items);
	}
}

/*<Codenesium>
    <Hash>6ab7ab50debca87eca391451fec67fc8</Hash>
</Codenesium>*/