using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepStepRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2f51034c15d38722917238dabb095a6d</Hash>
</Codenesium>*/