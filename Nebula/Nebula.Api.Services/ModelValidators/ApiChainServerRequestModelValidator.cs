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
	public class ApiChainServerRequestModelValidator : AbstractValidator<ApiChainServerRequestModel>, IApiChainServerRequestModelValidator
	{
		private int existingRecordId;

		protected IChainRepository ChainRepository { get; private set; }

		public ApiChainServerRequestModelValidator(IChainRepository chainRepository)
		{
			this.ChainRepository = chainRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainServerRequestModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainServerRequestModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>1e2be7a89841dc1f8bbb17d35f768f85</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/