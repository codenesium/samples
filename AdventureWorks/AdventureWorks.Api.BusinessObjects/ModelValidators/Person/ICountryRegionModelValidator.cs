using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCountryRegionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>8a66c05ce72404c9897ac2444b6fda89</Hash>
</Codenesium>*/