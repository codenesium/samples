using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiTableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>04b0ec837ebeb28e4fef536efb1b605a</Hash>
</Codenesium>*/