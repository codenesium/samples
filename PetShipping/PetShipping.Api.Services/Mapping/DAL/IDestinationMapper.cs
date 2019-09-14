using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALDestinationMapper
	{
		Destination MapModelToEntity(
			int id,
			ApiDestinationServerRequestModel model);

		ApiDestinationServerResponseModel MapEntityToModel(
			Destination item);

		List<ApiDestinationServerResponseModel> MapEntityToModel(
			List<Destination> items);
	}
}

/*<Codenesium>
    <Hash>451fd6c68ad8b76920370408f18aae84</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/