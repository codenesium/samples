using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e8f3be4a9e29144042962866e04be29b</Hash>
</Codenesium>*/