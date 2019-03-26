using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCultureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCultureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>291ed7e58ef943632a40c3332e56dc9e</Hash>
</Codenesium>*/