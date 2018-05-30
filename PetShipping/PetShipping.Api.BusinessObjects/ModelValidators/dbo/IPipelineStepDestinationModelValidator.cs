using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ac79e77927286cdbcc5b58c4dfab3fd</Hash>
</Codenesium>*/