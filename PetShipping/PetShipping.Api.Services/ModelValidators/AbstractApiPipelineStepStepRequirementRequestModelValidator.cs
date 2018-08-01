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
	public abstract class AbstractApiPipelineStepStepRequirementRequestModelValidator : AbstractValidator<ApiPipelineStepStepRequirementRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;

		public AbstractApiPipelineStepStepRequirementRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
		{
			this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).Length(0, 2147483647);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		public virtual void RequirementMetRules()
		{
		}

		private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepStepRequirementRepository.GetPipelineStep(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4d158355bd632e612bf34d90b61e2270</Hash>
</Codenesium>*/