using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8327ceeab3c91bb46f598065f67f79ff</Hash>
</Codenesium>*/