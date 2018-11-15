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
			ApiCountryRequirementServerRequestModel model);

		ApiCountryRequirementServerResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement);

		List<ApiCountryRequirementServerResponseModel> MapBOToModel(
			List<BOCountryRequirement> items);
	}
}

/*<Codenesium>
    <Hash>5f5d7e5261280e61076050d88072ec07</Hash>
</Codenesium>*/