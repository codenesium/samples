using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>32ba8f7d2d1bb841f42bc007bb18db3a</Hash>
</Codenesium>*/