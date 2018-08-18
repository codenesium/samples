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
    <Hash>393344c02dd532171f8a1fdafa26a504</Hash>
</Codenesium>*/