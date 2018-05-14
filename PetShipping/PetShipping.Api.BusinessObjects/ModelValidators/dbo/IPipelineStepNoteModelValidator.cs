using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStepNoteModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0dc9e1983f2622977a59f3323d8d878e</Hash>
</Codenesium>*/