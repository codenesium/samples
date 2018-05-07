using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStepModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>35d9da84c73eb8b7f4b87a0f85686029</Hash>
</Codenesium>*/