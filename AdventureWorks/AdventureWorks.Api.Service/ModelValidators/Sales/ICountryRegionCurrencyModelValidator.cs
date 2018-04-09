using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICountryRegionCurrencyModelValidator
	{
		ValidationResult Validate(CountryRegionCurrencyModel entity);

		Task<ValidationResult> ValidateAsync(CountryRegionCurrencyModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>6a5d9513ed0fae906f246a246e99fb1d</Hash>
</Codenesium>*/