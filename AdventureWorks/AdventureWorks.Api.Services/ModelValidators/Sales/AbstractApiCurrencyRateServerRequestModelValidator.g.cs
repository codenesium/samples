using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCurrencyRateServerRequestModelValidator : AbstractValidator<ApiCurrencyRateServerRequestModel>
	{
		private int existingRecordId;

		protected ICurrencyRateRepository CurrencyRateRepository { get; private set; }

		public AbstractApiCurrencyRateServerRequestModelValidator(ICurrencyRateRepository currencyRateRepository)
		{
			this.CurrencyRateRepository = currencyRateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCurrencyRateServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AverageRateRules()
		{
		}

		public virtual void CurrencyRateDateRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => (!x?.CurrencyRateDate.IsEmptyOrZeroOrNull() ?? false) || (!x?.FromCurrencyCode.IsEmptyOrZeroOrNull() ?? false) || (!x?.ToCurrencyCode.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateServerRequestModel.CurrencyRateDate)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void EndOfDayRateRules()
		{
		}

		public virtual void FromCurrencyCodeRules()
		{
			this.RuleFor(x => x.FromCurrencyCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FromCurrencyCode).MustAsync(this.BeValidCurrencyByFromCurrencyCode).When(x => !x?.FromCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
			this.RuleFor(x => x.FromCurrencyCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ToCurrencyCodeRules()
		{
			this.RuleFor(x => x.ToCurrencyCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ToCurrencyCode).MustAsync(this.BeValidCurrencyByToCurrencyCode).When(x => !x?.ToCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
			this.RuleFor(x => x.ToCurrencyCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCurrencyByFromCurrencyCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.CurrencyRateRepository.CurrencyByFromCurrencyCode(id);

			return record != null;
		}

		protected async Task<bool> BeValidCurrencyByToCurrencyCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.CurrencyRateRepository.CurrencyByToCurrencyCode(id);

			return record != null;
		}

		protected async Task<bool> BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode(ApiCurrencyRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			CurrencyRate record = await this.CurrencyRateRepository.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(model.CurrencyRateDate, model.FromCurrencyCode, model.ToCurrencyCode);

			if (record == null || (this.existingRecordId != default(int) && record.CurrencyRateID == this.existingRecordId))
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
    <Hash>dd692bc8548873262a79edbae2e7b7a3</Hash>
</Codenesium>*/