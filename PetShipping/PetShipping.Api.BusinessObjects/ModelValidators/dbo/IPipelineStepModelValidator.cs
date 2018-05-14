using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b56952f5780928fa23189dce27f85b78</Hash>
</Codenesium>*/