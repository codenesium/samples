using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiHandlerPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>627d43b64510789299a5e203bdc16bd1</Hash>
</Codenesium>*/