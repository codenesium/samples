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
	public abstract class AbstractApiClaspServerRequestModelValidator : AbstractValidator<ApiClaspServerRequestModel>
	{
		private int existingRecordId;

		protected IClaspRepository ClaspRepository { get; private set; }

		public AbstractApiClaspServerRequestModelValidator(IClaspRepository claspRepository)
		{
			this.ClaspRepository = claspRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiClaspServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NextChainIdRules()
		{
			this.RuleFor(x => x.NextChainId).MustAsync(this.BeValidChainByNextChainId).When(x => !x?.NextChainId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PreviousChainIdRules()
		{
			this.RuleFor(x => x.PreviousChainId).MustAsync(this.BeValidChainByPreviousChainId).When(x => !x?.PreviousChainId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidChainByNextChainId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ClaspRepository.ChainByNextChainId(id);

			return record != null;
		}

		protected async Task<bool> BeValidChainByPreviousChainId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ClaspRepository.ChainByPreviousChainId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a2f8849f6bad149480a72f8183a218ba</Hash>
</Codenesium>*/