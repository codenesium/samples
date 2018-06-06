using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>60bd18819c5f747b4d1cc96ebca832d2</Hash>
</Codenesium>*/