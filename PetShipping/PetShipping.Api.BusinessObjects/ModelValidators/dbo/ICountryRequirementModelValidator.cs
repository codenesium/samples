using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiCountryRequirementModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b34b497515a588ee4da64e62a24e14d1</Hash>
</Codenesium>*/