using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1da52b4ee7c4c1cec697843af9369194</Hash>
</Codenesium>*/