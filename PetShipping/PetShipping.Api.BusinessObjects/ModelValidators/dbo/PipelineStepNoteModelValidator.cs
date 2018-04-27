using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineStepNoteModelValidator: AbstractPipelineStepNoteModelValidator, IPipelineStepNoteModelValidator
	{
		public PipelineStepNoteModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineStepNoteModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepNoteModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>10bb857bb08d5631e40536db5d9e13d9</Hash>
</Codenesium>*/