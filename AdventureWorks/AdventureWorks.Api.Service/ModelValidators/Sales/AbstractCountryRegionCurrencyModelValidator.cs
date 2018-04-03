using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractCountryRegionCurrencyModelValidator: AbstractValidator<CountryRegionCurrencyModel>
	{
		public new ValidationResult Validate(CountryRegionCurrencyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CountryRegionCurrencyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CurrencyCodeRules()
		{
			RuleFor(x => x.CurrencyCode).NotNull();
			RuleFor(x => x.CurrencyCode).Length(0,3);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>a2973fa75b6f8a9a50a53e1d64eea0a7</Hash>
</Codenesium>*/