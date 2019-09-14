using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCountryMapper
	{
		Country MapModelToEntity(
			int id,
			ApiCountryServerRequestModel model);

		ApiCountryServerResponseModel MapEntityToModel(
			Country item);

		List<ApiCountryServerResponseModel> MapEntityToModel(
			List<Country> items);
	}
}

/*<Codenesium>
    <Hash>2944f31f58f147be5d4b58fa7dec337f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/