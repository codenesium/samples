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
	public abstract class AbstractApiPipelineStepStepRequirementRequestModelValidator: AbstractValidator<ApiPipelineStepStepRequirementRequestModel>
	{
		public new ValidationResult Validate(ApiPipelineStepStepRequirementRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementRequestModel model)
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
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		public virtual void RequirementMetRules()
		{
			this.RuleFor(x => x.RequirementMet).NotNull();
		}

		private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>bee55791aa3a9a649a9e6d50b1e80181</Hash>
</Codenesium>*/