using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatuRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatuRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatuRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>85db0cdfb20eeb37de6af43202e447c4</Hash>
</Codenesium>*/