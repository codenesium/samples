using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLCountryMapper
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
    <Hash>97febeb6548770bdc7283bbab08a1151</Hash>
</Codenesium>*/