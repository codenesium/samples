using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStepDestinationModelValidator: AbstractValidator<ApiPipelineStepDestinationModel>
	{
		public new ValidationResult Validate(ApiPipelineStepDestinationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepDestinationModel model)
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
			return this.DestinationRepository.Get(id) != null;
		}

		private bool BeValidPipelineStep(int id)
		{
			return this.PipelineStepRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>8df27007b7f02f4d76d7db761e63eaf7</Hash>
</Codenesium>*/