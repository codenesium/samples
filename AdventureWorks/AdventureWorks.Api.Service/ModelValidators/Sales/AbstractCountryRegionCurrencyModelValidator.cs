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

		public bool BeValidCountryRegion(string id)
		{
			Response response = new Response();

			this.CountryRegionRepository.GetById(id,response);
			return response.CountryRegions.Count > 0;
		}

		public bool BeValidCurrency(string id)
		{
			Response response = new Response();

			this.CurrencyRepository.GetById(id,response);
			return response.Currencies.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>47327ac60c5504138140e4227a157d5a</Hash>
</Codenesium>*/