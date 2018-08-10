using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonRefRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRefRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d43a3f01c92cdd7de9718e567b2a3a78</Hash>
</Codenesium>*/