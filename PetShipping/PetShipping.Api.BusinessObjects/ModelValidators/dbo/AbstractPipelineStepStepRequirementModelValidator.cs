using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStepStepRequirementModelValidator: AbstractValidator<ApiPipelineStepStepRequirementModel>
	{
		public new ValidationResult Validate(ApiPipelineStepStepRequirementModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).NotNull();
			this.RuleFor(x => x.Details).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).Must(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		public virtual void RequirementMetRules()
		{
			this.RuleFor(x => x.RequirementMet).NotNull();
		}

		private bool BeValidPipelineStep(int id)
		{
			return this.PipelineStepRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ce65952ae48b7e0034175e9f4b8e6679</Hash>
</Codenesium>*/