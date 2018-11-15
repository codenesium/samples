using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>661844f5f85c72c4187df8f701030f30</Hash>
</Codenesium>*/