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
    <Hash>92f10f3a8281440fd663e35119dca6f5</Hash>
</Codenesium>*/