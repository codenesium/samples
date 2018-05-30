using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>69cf99052e65349adaa06942b7986084</Hash>
</Codenesium>*/