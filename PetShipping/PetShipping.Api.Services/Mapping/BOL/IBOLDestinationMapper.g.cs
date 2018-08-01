using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLDestinationMapper
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
    <Hash>46d5366039f0967eae1c1ec9815582d8</Hash>
</Codenesium>*/