using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5329003290cd13885af6e1306f31e24c</Hash>
</Codenesium>*/