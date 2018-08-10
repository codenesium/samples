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
    <Hash>5cad57b2860d47a9a117a42f1d382f24</Hash>
</Codenesium>*/