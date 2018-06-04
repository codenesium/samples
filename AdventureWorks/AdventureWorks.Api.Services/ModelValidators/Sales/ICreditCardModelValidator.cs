using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b394efc78f11e2ae2e2f45416797b74f</Hash>
</Codenesium>*/