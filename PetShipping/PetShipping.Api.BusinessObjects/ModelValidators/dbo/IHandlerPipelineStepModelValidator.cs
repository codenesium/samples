using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiHandlerPipelineStepModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7fac985498927433092fa6857a98e23b</Hash>
</Codenesium>*/