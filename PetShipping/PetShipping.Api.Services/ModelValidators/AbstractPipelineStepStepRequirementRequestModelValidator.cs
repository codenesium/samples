using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiPipelineStepStepRequirementRequestModelValidator: AbstractValidator<ApiPipelineStepStepRequirementRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPipelineStepStepRequirementRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>3ac5067ac2df83b69089bc9bd550c2e0</Hash>
</Codenesium>*/