using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPhoneNumberTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6ead6f25393c679d414d251b74419373</Hash>
</Codenesium>*/