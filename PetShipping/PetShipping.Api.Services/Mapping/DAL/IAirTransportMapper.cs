using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALAirTransportMapper
	{
		AirTransport MapModelToEntity(
			int id,
			ApiAirTransportServerRequestModel model);

		ApiAirTransportServerResponseModel MapEntityToModel(
			AirTransport item);

		List<ApiAirTransportServerResponseModel> MapEntityToModel(
			List<AirTransport> items);
	}
}

/*<Codenesium>
    <Hash>5b9f9d090342264e4e7e3bcb6f5bcb81</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/