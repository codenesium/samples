using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiCountryRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>812e8327894968322e6d8315d82b4757</Hash>
</Codenesium>*/