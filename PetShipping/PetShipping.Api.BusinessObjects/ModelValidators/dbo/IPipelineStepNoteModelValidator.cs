using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepNoteModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStepNoteModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStepNoteModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5528ed9ae9d738bcb23bc2a534c8b795</Hash>
</Codenesium>*/