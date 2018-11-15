using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLAirTransportMapper
	{
		BOAirTransport MapModelToBO(
			int airlineId,
			ApiAirTransportServerRequestModel model);

		ApiAirTransportServerResponseModel MapBOToModel(
			BOAirTransport boAirTransport);

		List<ApiAirTransportServerResponseModel> MapBOToModel(
			List<BOAirTransport> items);
	}
}

/*<Codenesium>
    <Hash>1299ba40737ea3f6e367545bfdd13135</Hash>
</Codenesium>*/