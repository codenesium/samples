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

		private ICurrencyRateRepository currencyRateRepository;

		public AbstractApiCurrencyRateServerRequestModelValidator(ICurrencyRateRepository currencyRateRepository)
		{
			this.currencyRateRepository = currencyRateRepository;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => !x?.CurrencyRateDate.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateServerRequestModel.CurrencyRateDate));
		}

		public virtual void EndOfDayRateRules()
		{
		}

		public virtual void FromCurrencyCodeRules()
		{
			this.RuleFor(x => x.FromCurrencyCode).NotNull();
			this.RuleFor(x => x.FromCurrencyCode).MustAsync(this.BeValidCurrencyByFromCurrencyCode).When(x => !x?.FromCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => !x?.FromCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateServerRequestModel.FromCurrencyCode));
			this.RuleFor(x => x.FromCurrencyCode).Length(0, 3);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ToCurrencyCodeRules()
		{
			this.RuleFor(x => x.ToCurrencyCode).NotNull();
			this.RuleFor(x => x.ToCurrencyCode).MustAsync(this.BeValidCurrencyByToCurrencyCode).When(x => !x?.ToCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => !x?.ToCurrencyCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateServerRequestModel.ToCurrencyCode));
			this.RuleFor(x => x.ToCurrencyCode).Length(0, 3);
		}

		private async Task<bool> BeValidCurrencyByFromCurrencyCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.currencyRateRepository.CurrencyByFromCurrencyCode(id);

			return record != null;
		}

		private async Task<bool> BeValidCurrencyByToCurrencyCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.currencyRateRepository.CurrencyByToCurrencyCode(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode(ApiCurrencyRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			CurrencyRate record = await this.currencyRateRepository.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(model.CurrencyRateDate, model.FromCurrencyCode, model.ToCurrencyCode);

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
    <Hash>04d1b6558e5f2f4d1e10fc28bcdea24d</Hash>
</Codenesium>*/