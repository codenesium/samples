using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLAirTransportMapper
	{
		BOAirTransport MapModelToBO(
			int airlineId,
			ApiAirTransportRequestModel model);

		ApiAirTransportResponseModel MapBOToModel(
			BOAirTransport boAirTransport);

		List<ApiAirTransportResponseModel> MapBOToModel(
			List<BOAirTransport> items);
	}
}

/*<Codenesium>
    <Hash>776397d3067f15c5ba44be6a9ad6e1e3</Hash>
</Codenesium>*/