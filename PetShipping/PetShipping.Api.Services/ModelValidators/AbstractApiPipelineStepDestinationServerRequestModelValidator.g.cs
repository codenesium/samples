using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.DestinationId).MustAsync(this.BeValidDestinationByDestinationId).When(x => !x?.DestinationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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
    <Hash>01c531229e664f9efe8ed26c20f94db8</Hash>
</Codenesium>*/