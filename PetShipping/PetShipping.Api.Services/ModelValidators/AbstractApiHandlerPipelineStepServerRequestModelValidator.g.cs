using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiHandlerPipelineStepServerRequestModelValidator : AbstractValidator<ApiHandlerPipelineStepServerRequestModel>
	{
		private int existingRecordId;

		private IHandlerPipelineStepRepository handlerPipelineStepRepository;

		public AbstractApiHandlerPipelineStepServerRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
		{
			this.handlerPipelineStepRepository = handlerPipelineStepRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiHandlerPipelineStepServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandlerByHandlerId).When(x => !x?.HandlerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidHandlerByHandlerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.handlerPipelineStepRepository.HandlerByHandlerId(id);

			return record != null;
		}

		private async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.handlerPipelineStepRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b909ce94a16a0bdf70e05ec50c76780c</Hash>
</Codenesium>*/