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
	public abstract class AbstractApiOtherTransportRequestModelValidator: AbstractValidator<ApiOtherTransportRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiOtherTransportRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiOtherTransportRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IHandlerRepository HandlerRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).NotNull();
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
		{
			var record = await this.HandlerRepository.Get(id);

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
    <Hash>f9c027e61136a279c10d4af083510754</Hash>
</Codenesium>*/