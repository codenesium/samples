using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
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
    <Hash>f9b80bca022a3d8f92343649951d7404</Hash>
</Codenesium>*/