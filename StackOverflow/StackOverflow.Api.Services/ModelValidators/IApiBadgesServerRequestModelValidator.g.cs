using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>21022a19f1ff44bc6a3e7407f985660a</Hash>
</Codenesium>*/