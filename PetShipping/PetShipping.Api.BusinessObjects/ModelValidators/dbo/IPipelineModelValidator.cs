using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>66f5d1a39e2ad73870b64d929a5ae462</Hash>
</Codenesium>*/