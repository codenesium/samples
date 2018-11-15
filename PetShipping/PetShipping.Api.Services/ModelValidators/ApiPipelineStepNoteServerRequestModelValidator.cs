using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepNoteServerRequestModelValidator : AbstractApiPipelineStepNoteServerRequestModelValidator, IApiPipelineStepNoteServerRequestModelValidator
	{
		public ApiPipelineStepNoteServerRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
			: base(pipelineStepNoteRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteServerRequestModel model)
		{
			this.EmployeeIdRules();
			this.NoteRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteServerRequestModel model)
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
    <Hash>d9f89ab0a71d557161fdf8e3893b4897</Hash>
</Codenesium>*/