using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICountryRegionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CountryRegionModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, CountryRegionModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>468ae02c84e9d778c0dd933949f970b4</Hash>
</Codenesium>*/