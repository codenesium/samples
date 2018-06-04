using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepStepRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>990560f875c1c7b397efd08c0733ab50</Hash>
</Codenesium>*/