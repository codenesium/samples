using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStepNoteRequestModelValidator: AbstractValidator<ApiPipelineStepNoteRequestModel>
	{
		public new ValidationResult Validate(ApiPipelineStepNoteRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).NotNull();
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EmployeeRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>758336e102653f95c5c1dc64cfef787f</Hash>
</Codenesium>*/