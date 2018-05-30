using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiCountryRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>687251c5e4d8be4cd9ef6d5a702919d4</Hash>
</Codenesium>*/