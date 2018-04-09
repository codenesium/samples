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

		public ICountryRegionRepository CountryRegionRepository {get; set;}
		public ICurrencyRepository CurrencyRepository {get; set;}
		public virtual void CurrencyCodeRules()
		{
			RuleFor(x => x.CurrencyCode).NotNull();
			RuleFor(x => x.CurrencyCode).Must(BeValidCurrency).When(x => x ?.CurrencyCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.CurrencyCode).Length(0,3);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCountryRegion(string id)
		{
			return this.CountryRegionRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidCurrency(string id)
		{
			return this.CurrencyRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>72b23faa219866d4ef5aedf5d34d3176</Hash>
</Codenesium>*/