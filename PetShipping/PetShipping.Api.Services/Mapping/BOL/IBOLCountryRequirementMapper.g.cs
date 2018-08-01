using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLCountryRequirementMapper
	{
		BOCountryRequirement MapModelToBO(
			int id,
			ApiCountryRequirementRequestModel model);

		ApiCountryRequirementResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement);

		List<ApiCountryRequirementResponseModel> MapBOToModel(
			List<BOCountryRequirement> items);
	}
}

/*<Codenesium>
    <Hash>93101507ab89bbc450cecfd04a948ce9</Hash>
</Codenesium>*/