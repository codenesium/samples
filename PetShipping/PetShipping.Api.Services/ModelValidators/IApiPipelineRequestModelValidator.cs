using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4860ae74ec0bd5a8ec51ee4f9420d886</Hash>
</Codenesium>*/