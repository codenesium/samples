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
			ApiCountryRequestModel model);

		ApiCountryResponseModel MapBOToModel(
			BOCountry boCountry);

		List<ApiCountryResponseModel> MapBOToModel(
			List<BOCountry> items);
	}
}

/*<Codenesium>
    <Hash>4561024fe21b80af4c6620d99fcbcca0</Hash>
</Codenesium>*/