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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>696a9fe8d689cf1e51285610b24255d5</Hash>
</Codenesium>*/