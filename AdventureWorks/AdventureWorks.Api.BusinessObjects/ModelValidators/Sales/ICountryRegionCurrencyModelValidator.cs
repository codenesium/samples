using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICountryRegionCurrencyModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CountryRegionCurrencyModel model);
		Task<ValidationResult>  ValidateUpdateAsync(string id, CountryRegionCurrencyModel model);
		Task<ValidationResult>  ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>8a6ae2e34cadd1490d6b46912b8e6f30</Hash>
</Codenesium>*/