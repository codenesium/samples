using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepStepRequirementModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStepStepRequirementModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepStepRequirementModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5c3d00948d9a0048a4e577a8d3df5db5</Hash>
</Codenesium>*/