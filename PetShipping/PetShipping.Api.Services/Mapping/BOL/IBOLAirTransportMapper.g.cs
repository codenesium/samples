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
			ApiAirTransportRequestModel model);

		ApiAirTransportResponseModel MapBOToModel(
			BOAirTransport boAirTransport);

		List<ApiAirTransportResponseModel> MapBOToModel(
			List<BOAirTransport> items);
	}
}

/*<Codenesium>
    <Hash>b77d98f53ad8ba00cd0686c8f7119836</Hash>
</Codenesium>*/