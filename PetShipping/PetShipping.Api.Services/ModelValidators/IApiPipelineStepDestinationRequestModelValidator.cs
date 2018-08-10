using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>912ec7f08709248a9606bcafc620f230</Hash>
</Codenesium>*/