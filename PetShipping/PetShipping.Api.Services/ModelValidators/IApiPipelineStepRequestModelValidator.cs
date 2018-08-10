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
    <Hash>83b52bb08c9d383c747cc6987856238e</Hash>
</Codenesium>*/