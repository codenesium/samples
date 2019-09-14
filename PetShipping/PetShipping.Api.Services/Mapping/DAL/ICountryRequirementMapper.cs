using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCountryRequirementMapper
	{
		CountryRequirement MapModelToEntity(
			int id,
			ApiCountryRequirementServerRequestModel model);

		ApiCountryRequirementServerResponseModel MapEntityToModel(
			CountryRequirement item);

		List<ApiCountryRequirementServerResponseModel> MapEntityToModel(
			List<CountryRequirement> items);
	}
}

/*<Codenesium>
    <Hash>f050fb222393ee141b2ac0aafc4fe962</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/