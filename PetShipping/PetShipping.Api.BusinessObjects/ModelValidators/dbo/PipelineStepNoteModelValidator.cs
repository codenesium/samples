using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineStepNoteModelValidator: AbstractApiPipelineStepNoteModelValidator, IApiPipelineStepNoteModelValidator
	{
		public ApiPipelineStepNoteModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteModel model)
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
    <Hash>5a79f0b4eff34699a00c03a8b5724213</Hash>
</Codenesium>*/