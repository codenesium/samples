using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d701dc0b120b7c62adc8be96b489b7af</Hash>
</Codenesium>*/