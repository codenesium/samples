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
    <Hash>6d1eb358af0ac6fcd6819a878e93f72b</Hash>
</Codenesium>*/