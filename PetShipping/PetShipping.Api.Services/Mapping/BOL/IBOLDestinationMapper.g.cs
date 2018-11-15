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
			ApiDestinationServerRequestModel model);

		ApiDestinationServerResponseModel MapBOToModel(
			BODestination boDestination);

		List<ApiDestinationServerResponseModel> MapBOToModel(
			List<BODestination> items);
	}
}

/*<Codenesium>
    <Hash>67ee945cab66f425849d2989bc574e21</Hash>
</Codenesium>*/