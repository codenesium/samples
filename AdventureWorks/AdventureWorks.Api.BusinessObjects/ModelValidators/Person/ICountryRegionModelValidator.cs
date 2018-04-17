using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICountryRegionModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CountryRegionModel model);
		Task<ValidationResult>  ValidateUpdateAsync(string id, CountryRegionModel model);
		Task<ValidationResult>  ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>9b85848854406159ab3269b9b59905d0</Hash>
</Codenesium>*/