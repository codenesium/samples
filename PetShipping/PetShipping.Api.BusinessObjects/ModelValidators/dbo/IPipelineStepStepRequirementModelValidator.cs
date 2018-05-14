using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepStepRequirementModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ae63f18178c85a5de0afdbd8bcd5238f</Hash>
</Codenesium>*/