using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCountryRegionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>28be560375c41db33abe8bae9897ff34</Hash>
</Codenesium>*/