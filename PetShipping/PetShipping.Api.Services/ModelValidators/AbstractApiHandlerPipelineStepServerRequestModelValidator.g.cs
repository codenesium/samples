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
	public abstract class AbstractApiHandlerPipelineStepServerRequestModelValidator : AbstractValidator<ApiHandlerPipelineStepServerRequestModel>
	{
		private int existingRecordId;

		protected IHandlerPipelineStepRepository HandlerPipelineStepRepository { get; private set; }

		public AbstractApiHandlerPipelineStepServerRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
		{
			this.HandlerPipelineStepRepository = handlerPipelineStepRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiHandlerPipelineStepServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandlerByHandlerId).When(x => !x?.HandlerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidHandlerByHandlerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.HandlerPipelineStepRepository.HandlerByHandlerId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.HandlerPipelineStepRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8563e7b296ecdf4d8900b70225ef7c60</Hash>
</Codenesium>*/