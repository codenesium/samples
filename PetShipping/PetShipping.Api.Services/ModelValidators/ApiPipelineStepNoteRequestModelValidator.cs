using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepNoteRequestModelValidator : AbstractApiPipelineStepNoteRequestModelValidator, IApiPipelineStepNoteRequestModelValidator
	{
		public ApiPipelineStepNoteRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
			: base(pipelineStepNoteRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ee84f9556c9bb0236547dd1242bdd083</Hash>
</Codenesium>*/