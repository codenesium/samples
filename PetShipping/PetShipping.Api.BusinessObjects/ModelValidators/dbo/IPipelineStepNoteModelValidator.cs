using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepNoteModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStepNoteModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepNoteModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24b1bf2cc310ef014dfe48d14f4d131f</Hash>
</Codenesium>*/