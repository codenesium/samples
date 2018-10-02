using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiVPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>76ac4f91c67099400e2a59aa3fce3fa3</Hash>
</Codenesium>*/