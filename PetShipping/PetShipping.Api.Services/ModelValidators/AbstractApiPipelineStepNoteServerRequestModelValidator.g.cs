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
	public abstract class AbstractApiPipelineStepNoteServerRequestModelValidator : AbstractValidator<ApiPipelineStepNoteServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineStepNoteRepository PipelineStepNoteRepository { get; private set; }

		public AbstractApiPipelineStepNoteServerRequestModelValidator(IPipelineStepNoteRepository pipelineStepNoteRepository)
		{
			this.PipelineStepNoteRepository = pipelineStepNoteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => !x?.EmployeeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidEmployeeByEmployeeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepNoteRepository.EmployeeByEmployeeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepNoteRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>dc437280c5098049388c1a6fcef0c85c</Hash>
</Codenesium>*/