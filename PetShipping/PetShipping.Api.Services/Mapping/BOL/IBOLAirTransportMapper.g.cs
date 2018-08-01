using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f31e734dc8741b724cf621709a88047c</Hash>
</Codenesium>*/