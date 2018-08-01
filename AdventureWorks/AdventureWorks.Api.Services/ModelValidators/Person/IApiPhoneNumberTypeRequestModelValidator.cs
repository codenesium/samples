using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>c6facf6ac7998e6e5b90a9f5fb82049a</Hash>
</Codenesium>*/