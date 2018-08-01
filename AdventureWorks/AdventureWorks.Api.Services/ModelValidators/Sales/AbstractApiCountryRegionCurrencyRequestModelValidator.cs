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
	public abstract class AbstractApiCountryRegionCurrencyRequestModelValidator : AbstractValidator<ApiCountryRegionCurrencyRequestModel>
	{
		private string existingRecordId;

		private ICountryRegionCurrencyRepository countryRegionCurrencyRepository;

		public AbstractApiCountryRegionCurrencyRequestModelValidator(ICountryRegionCurrencyRepository countryRegionCurrencyRepository)
		{
			this.countryRegionCurrencyRepository = countryRegionCurrencyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CurrencyCodeRules()
		{
			this.RuleFor(x => x.CurrencyCode).NotNull();
			this.RuleFor(x => x.CurrencyCode).MustAsync(this.BeValidCurrency).When(x => x?.CurrencyCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.CurrencyCode).Length(0, 3);
		}

		public virtual void ModifiedDateRules()
		{
		}

		private async Task<bool> BeValidCurrency(string id,  CancellationToken cancellationToken)
		{
			var record = await this.countryRegionCurrencyRepository.GetCurrency(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8eb90ad8f5b5872b2ac50c192bd85cfe</Hash>
</Codenesium>*/