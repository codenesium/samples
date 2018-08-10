using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>80884a8c25750371c4dde090c96c38ea</Hash>
</Codenesium>*/