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
    <Hash>6660435f03430649f5f950754aca2495</Hash>
</Codenesium>*/