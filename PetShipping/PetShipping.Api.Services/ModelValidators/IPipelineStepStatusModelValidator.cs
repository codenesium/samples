using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b2d1c6f8992c41746d0935bb4f07a131</Hash>
</Codenesium>*/