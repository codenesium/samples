using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5db829dbaa67b8b43cc3f5c87b8257b</Hash>
</Codenesium>*/