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

		protected IPipelineStepStepRequirementRepository PipelineStepStepRequirementRepository { get; private set; }

		public AbstractApiPipelineStepStepRequirementServerRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
		{
			this.PipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Details).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void RequirementMetRules()
		{
		}

		protected async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepStepRequirementRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3bdcdac1c83796682d2940ce3f42bc0d</Hash>
</Codenesium>*/