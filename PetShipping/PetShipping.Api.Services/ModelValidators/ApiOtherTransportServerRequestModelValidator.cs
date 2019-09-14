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
	public class ApiOtherTransportServerRequestModelValidator : AbstractValidator<ApiOtherTransportServerRequestModel>, IApiOtherTransportServerRequestModelValidator
	{
		private int existingRecordId;

		protected IOtherTransportRepository OtherTransportRepository { get; private set; }

		public ApiOtherTransportServerRequestModelValidator(IOtherTransportRepository otherTransportRepository)
		{
			this.OtherTransportRepository = otherTransportRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOtherTransportServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportServerRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportServerRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>93eb0fe8a9ee1be849287a731c1ca742</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/