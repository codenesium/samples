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
			List<BODestination> bos);
	}
}

/*<Codenesium>
    <Hash>89d9eb791708b5ce82f3c03b762003d8</Hash>
</Codenesium>*/