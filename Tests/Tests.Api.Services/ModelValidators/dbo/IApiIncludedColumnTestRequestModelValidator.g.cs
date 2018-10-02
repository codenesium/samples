using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiIncludedColumnTestRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIncludedColumnTestRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIncludedColumnTestRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b45232ab7bba8a4efd4982bbfb872a16</Hash>
</Codenesium>*/