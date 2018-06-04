using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b82a0ffde039a6f43b10ebd1cebf0f28</Hash>
</Codenesium>*/