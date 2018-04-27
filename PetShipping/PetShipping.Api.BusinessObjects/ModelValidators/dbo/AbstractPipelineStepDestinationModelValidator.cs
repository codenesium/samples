using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractPipelineStepDestinationModelValidator: AbstractValidator<PipelineStepDestinationModel>
	{
		public new ValidationResult Validate(PipelineStepDestinationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PipelineStepDestinationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDestinationRepository DestinationRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void DestinationIdRules()
		{
			this.RuleFor(x => x.DestinationId).NotNull();
			this.RuleFor(x => x.DestinationId).Must(this.BeValidDestination).When(x => x ?.DestinationId != null).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).Must(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private bool BeValidDestination(int id)
		{
			return this.DestinationRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPipelineStep(int id)
		{
			return this.PipelineStepRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>93d8739aa069073e3bb890845c355933</Hash>
</Codenesium>*/