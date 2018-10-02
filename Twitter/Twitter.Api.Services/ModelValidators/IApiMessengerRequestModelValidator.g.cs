using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessengerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMessengerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessengerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b379812a52772ddead26f72c27380fd4</Hash>
</Codenesium>*/