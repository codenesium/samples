using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLCountryRequirementMapper
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
    <Hash>1870430b8164ca37fe97263854afe0c2</Hash>
</Codenesium>*/