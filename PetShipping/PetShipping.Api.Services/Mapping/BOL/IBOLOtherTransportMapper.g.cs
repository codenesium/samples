using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLOtherTransportMapper
	{
		BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportServerRequestModel model);

		ApiOtherTransportServerResponseModel MapBOToModel(
			BOOtherTransport boOtherTransport);

		List<ApiOtherTransportServerResponseModel> MapBOToModel(
			List<BOOtherTransport> items);
	}
}

/*<Codenesium>
    <Hash>72397875a1c342f161738f276d2d2137</Hash>
</Codenesium>*/