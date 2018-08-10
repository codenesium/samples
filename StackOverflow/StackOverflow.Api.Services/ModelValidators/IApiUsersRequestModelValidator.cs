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
    <Hash>66dd13fe78325934b66a35feba5399b8</Hash>
</Codenesium>*/