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
	public class ApiClaspServerRequestModelValidator : AbstractValidator<ApiClaspServerRequestModel>, IApiClaspServerRequestModelValidator
	{
		private int existingRecordId;

		protected IClaspRepository ClaspRepository { get; private set; }

		public ApiClaspServerRequestModelValidator(IClaspRepository claspRepository)
		{
			this.ClaspRepository = claspRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiClaspServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClaspServerRequestModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspServerRequestModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>0cabd4fce30a4834c386e86f46f0b818</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/