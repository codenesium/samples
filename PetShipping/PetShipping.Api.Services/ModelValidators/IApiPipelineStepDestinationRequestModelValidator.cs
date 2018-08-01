using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>4298ed6589fd5f7a7f34f94e1169c646</Hash>
</Codenesium>*/