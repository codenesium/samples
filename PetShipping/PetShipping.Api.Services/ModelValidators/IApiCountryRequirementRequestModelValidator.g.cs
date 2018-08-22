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
    <Hash>08013dc0f744d6447878acfbff86d457</Hash>
</Codenesium>*/