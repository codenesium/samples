using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiRowVersionCheckServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1afa8919209d980b714913e875ff2957</Hash>
</Codenesium>*/