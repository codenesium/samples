using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
			List<BOCountryRequirement> bos);
	}
}

/*<Codenesium>
    <Hash>6848f3fc5da8a24580c8c442cd4d406b</Hash>
</Codenesium>*/