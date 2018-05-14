using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStepNoteModelValidator: AbstractValidator<ApiPipelineStepNoteModel>
	{
		public new ValidationResult Validate(ApiPipelineStepNoteModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).NotNull();
			this.RuleFor(x => x.EmployeeId).Must(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).Must(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.Get(id) != null;
		}

		private bool BeValidPipelineStep(int id)
		{
			return this.PipelineStepRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>473a9be2174c2249cc893d41ba026231</Hash>
</Codenesium>*/