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
			List<BOAirTransport> bos);
	}
}

/*<Codenesium>
    <Hash>e3cc738790daf7591f463e277185cf7f</Hash>
</Codenesium>*/