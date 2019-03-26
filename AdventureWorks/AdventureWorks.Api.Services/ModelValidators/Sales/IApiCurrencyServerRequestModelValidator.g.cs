using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a3b4a6a8c8bb91b1e7638af68c5c818d</Hash>
</Codenesium>*/