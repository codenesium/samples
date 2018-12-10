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
	public abstract class AbstractApiChainServerRequestModelValidator : AbstractValidator<ApiChainServerRequestModel>
	{
		private int existingRecordId;

		protected IChainRepository ChainRepository { get; private set; }

		public AbstractApiChainServerRequestModelValidator(IChainRepository chainRepository)
		{
			this.ChainRepository = chainRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChainStatusIdRules()
		{
			this.RuleFor(x => x.ChainStatusId).MustAsync(this.BeValidChainStatusByChainStatusId).When(x => !x?.ChainStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => (!x?.ExternalId.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiChainServerRequestModel.ExternalId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeamByTeamId).When(x => !x?.TeamId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidChainStatusByChainStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ChainRepository.ChainStatusByChainStatusId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTeamByTeamId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ChainRepository.TeamByTeamId(id);

			return record != null;
		}

		protected async Task<bool> BeUniqueByExternalId(ApiChainServerRequestModel model,  CancellationToken cancellationToken)
		{
			Chain record = await this.ChainRepository.ByExternalId(model.ExternalId);

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
    <Hash>62a61cd8388c539f439fbf0a75ccc6e6</Hash>
</Codenesium>*/