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
    <Hash>2dadceb15eb8e380e62fa202758e33d0</Hash>
</Codenesium>*/