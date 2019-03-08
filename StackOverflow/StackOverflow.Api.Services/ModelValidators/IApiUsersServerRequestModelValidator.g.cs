using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiUsersServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUsersServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>758ba40442a3477820e5f72f6f2fd39b</Hash>
</Codenesium>*/