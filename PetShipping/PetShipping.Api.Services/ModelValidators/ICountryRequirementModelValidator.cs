using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
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
    <Hash>b63dcb5dfe1d334000c34d41b900a868</Hash>
</Codenesium>*/