using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepNoteServerRequestModelValidator : AbstractValidator<ApiPipelineStepNoteServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepNoteRepository pipelineStepNoteRepository;

		public AbstractApiPipelineStepNoteServerRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => !x?.EmployeeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEmployeeByEmployeeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepNoteRepository.EmployeeByEmployeeId(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepNoteRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>031b1bc7e821e5a98d368b0e2ac627dd</Hash>
</Codenesium>*/