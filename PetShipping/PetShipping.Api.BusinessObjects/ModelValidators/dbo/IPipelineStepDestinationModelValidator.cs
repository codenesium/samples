using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepDestinationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>89dcdf1cf2ad0feae2c3818b408778b6</Hash>
</Codenesium>*/