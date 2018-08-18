using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e332df4438c578d3efb18ddcf09da8cc</Hash>
</Codenesium>*/