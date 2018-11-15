using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLCountryMapper
	{
		BOCountry MapModelToBO(
			int id,
			ApiCountryServerRequestModel model);

		ApiCountryServerResponseModel MapBOToModel(
			BOCountry boCountry);

		List<ApiCountryServerResponseModel> MapBOToModel(
			List<BOCountry> items);
	}
}

/*<Codenesium>
    <Hash>a6dcdb39deab77c4bed1272fcb174e2c</Hash>
</Codenesium>*/