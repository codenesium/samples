using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepNoteRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>431682eb032f6d62fece755ce25f3ac1</Hash>
</Codenesium>*/