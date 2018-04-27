using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IHandlerPipelineStepModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(HandlerPipelineStepModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, HandlerPipelineStepModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>666c151cc6e2bdf793fb99fcbf7a8cc4</Hash>
</Codenesium>*/