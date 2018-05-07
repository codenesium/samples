using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICountryRegionCurrencyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CountryRegionCurrencyModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, CountryRegionCurrencyModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>4dadd92e7900e5a22148add196123af4</Hash>
</Codenesium>*/