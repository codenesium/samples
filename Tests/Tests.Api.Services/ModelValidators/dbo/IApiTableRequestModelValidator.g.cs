using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1c79ce085c168ebd8aaece6bacbd8a7a</Hash>
</Codenesium>*/