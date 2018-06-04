using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiCountryRegionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>84c84fc348c119ed4703a1e0205b829a</Hash>
</Codenesium>*/