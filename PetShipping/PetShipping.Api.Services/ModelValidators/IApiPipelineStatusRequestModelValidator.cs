using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c5ebb35664f18e44b0df0f2323a4f946</Hash>
</Codenesium>*/