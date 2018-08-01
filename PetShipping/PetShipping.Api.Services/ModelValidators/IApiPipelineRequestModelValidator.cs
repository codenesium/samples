using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8b83349cbec4a58594a15d5d11fff558</Hash>
</Codenesium>*/