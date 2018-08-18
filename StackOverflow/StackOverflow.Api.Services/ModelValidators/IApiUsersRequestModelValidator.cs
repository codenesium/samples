using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiUsersRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUsersRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8fba1df8312754f774ecce19f45b426c</Hash>
</Codenesium>*/