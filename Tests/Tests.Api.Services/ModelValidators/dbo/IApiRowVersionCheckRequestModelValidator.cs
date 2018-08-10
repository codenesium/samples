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
    <Hash>a227f5122fe56ecaa61e68f1aff96442</Hash>
</Codenesium>*/