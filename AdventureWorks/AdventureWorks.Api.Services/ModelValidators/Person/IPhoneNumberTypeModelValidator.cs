using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPhoneNumberTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>be75f17e98988880acbd0d7bbae2c58b</Hash>
</Codenesium>*/