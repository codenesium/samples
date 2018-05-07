using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractPipelineStepModelValidator: AbstractValidator<PipelineStepModel>
	{
		public new ValidationResult Validate(PipelineStepModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PipelineStepModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPipelineStepStatusRepository PipelineStepStatusRepository { get; set; }
		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void PipelineStepStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStepStatusId).NotNull();
			this.RuleFor(x => x.PipelineStepStatusId).Must(this.BeValidPipelineStepStatus).When(x => x ?.PipelineStepStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ShipperIdRules()
		{
			this.RuleFor(x => x.ShipperId).NotNull();
			this.RuleFor(x => x.ShipperId).Must(this.BeValidEmployee).When(x => x ?.ShipperId != null).WithMessage("Invalid reference");
		}

		private bool BeValidPipelineStepStatus(int id)
		{
			return this.PipelineStepStatusRepository.Get(id) != null;
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>631a1c8c84c8ff8676d63d5c145e62a3</Hash>
</Codenesium>*/