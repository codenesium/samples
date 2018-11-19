using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiChainStatusServerRequestModelValidator : AbstractValidator<ApiChainStatusServerRequestModel>
	{
		private int existingRecordId;

		private IChainStatusRepository chainStatusRepository;

		public AbstractApiChainStatusServerRequestModelValidator(IChainStatusRepository chainStatusRepository)
		{
			this.chainStatusRepository = chainStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatusServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiChainStatusServerRequestModel model,  CancellationToken cancellationToken)
		{
			ChainStatus record = await this.chainStatusRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9c8d27e44fa14a1696c3a515fb6e70ef</Hash>
</Codenesium>*/