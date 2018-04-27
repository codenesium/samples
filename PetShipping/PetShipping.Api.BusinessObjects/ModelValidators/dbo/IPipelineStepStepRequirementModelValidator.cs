using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepStepRequirementModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStepStepRequirementModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStepStepRequirementModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ec27716d84be2d7f01771613b1f61a2a</Hash>
</Codenesium>*/