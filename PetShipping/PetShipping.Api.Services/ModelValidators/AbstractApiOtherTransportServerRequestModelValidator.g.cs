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
	public abstract class AbstractApiOtherTransportServerRequestModelValidator : AbstractValidator<ApiOtherTransportServerRequestModel>
	{
		private int existingRecordId;

		protected IOtherTransportRepository OtherTransportRepository { get; private set; }

		public AbstractApiOtherTransportServerRequestModelValidator(IOtherTransportRepository otherTransportRepository)
		{
			this.OtherTransportRepository = otherTransportRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOtherTransportServerRequestModel model, int id)
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
			var record = await this.OtherTransportRepository.HandlerByHandlerId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OtherTransportRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9a7afad892e4bd6d9ca0e6de68263e48</Hash>
</Codenesium>*/