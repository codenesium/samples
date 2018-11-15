using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepStepRequirementServerRequestModelValidator : AbstractValidator<ApiPipelineStepStepRequirementServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;

		public AbstractApiPipelineStepStepRequirementServerRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
		{
			this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DetailRules()
		{
			this.RuleFor(x => x.Detail).NotNull();
			this.RuleFor(x => x.Detail).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void RequirementMetRules()
		{
		}

		private async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepStepRequirementRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9b87198383b6c796d0b651a8b8ecf8e2</Hash>
</Codenesium>*/