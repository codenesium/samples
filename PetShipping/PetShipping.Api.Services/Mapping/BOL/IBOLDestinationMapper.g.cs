using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLDestinationMapper
	{
		BODestination MapModelToBO(
			int id,
			ApiDestinationRequestModel model);

		ApiDestinationResponseModel MapBOToModel(
			BODestination boDestination);

		List<ApiDestinationResponseModel> MapBOToModel(
			List<BODestination> items);
	}
}

/*<Codenesium>
    <Hash>bc5809a9a82ff18b3b8801ecc53cd21a</Hash>
</Codenesium>*/