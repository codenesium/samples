using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepNoteRequestModelValidator : AbstractValidator<ApiPipelineStepNoteRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepNoteRepository pipelineStepNoteRepository;

		public AbstractApiPipelineStepNoteRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => x?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => x?.PipelineStepId != null).WithMessage("Invalid reference");
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
    <Hash>bfd4545cd883be327b6a59d48bfb7ccc</Hash>
</Codenesium>*/