using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1baec142d189e61af3a1b4f18c013e73</Hash>
</Codenesium>*/