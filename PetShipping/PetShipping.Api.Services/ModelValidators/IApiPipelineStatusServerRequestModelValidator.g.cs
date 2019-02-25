using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>02c053a67b594e1c6093936f34cbe37a</Hash>
</Codenesium>*/