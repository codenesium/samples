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
	public abstract class AbstractApiPipelineStepDestinationRequestModelValidator: AbstractValidator<ApiPipelineStepDestinationRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPipelineStepDestinationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepDestinationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IDestinationRepository DestinationRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void DestinationIdRules()
		{
			this.RuleFor(x => x.DestinationId).NotNull();
			this.RuleFor(x => x.DestinationId).MustAsync(this.BeValidDestination).When(x => x ?.DestinationId != null).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidDestination(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DestinationRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>77e9c9be350f026d098c482731e288ce</Hash>
</Codenesium>*/