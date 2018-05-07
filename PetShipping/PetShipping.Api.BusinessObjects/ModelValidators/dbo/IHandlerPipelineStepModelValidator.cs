using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IHandlerPipelineStepModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(HandlerPipelineStepModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, HandlerPipelineStepModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>564eed38295412c7285fabcbf7fa1ecd</Hash>
</Codenesium>*/