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
			this.RuleFor(x => x.Detail).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Detail).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
    <Hash>bad2667d3f1830d3012a37340b699605</Hash>
</Codenesium>*/