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
	public abstract class AbstractApiPipelineStepDestinationServerRequestModelValidator : AbstractValidator<ApiPipelineStepDestinationServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepDestinationRepository pipelineStepDestinationRepository;

		public AbstractApiPipelineStepDestinationServerRequestModelValidator(IPipelineStepDestinationRepository pipelineStepDestinationRepository)
		{
			this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepDestinationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DestinationIdRules()
		{
			this.RuleFor(x => x.DestinationId).MustAsync(this.BeValidDestinationByDestinationId).When(x => !x?.DestinationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		private async Task<bool> BeValidDestinationByDestinationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepDestinationRepository.DestinationByDestinationId(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepDestinationRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d4a40b1880989b701a49b5ff6786b757</Hash>
</Codenesium>*/