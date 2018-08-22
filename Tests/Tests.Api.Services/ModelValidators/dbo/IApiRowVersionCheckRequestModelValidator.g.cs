using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiRowVersionCheckRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>00e253f395e1d592d410ce16ca445862</Hash>
</Codenesium>*/