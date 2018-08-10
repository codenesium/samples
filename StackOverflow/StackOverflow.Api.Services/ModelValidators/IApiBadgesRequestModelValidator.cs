using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5c7f636ff6ce05c3f71bfe17d6d07b5</Hash>
</Codenesium>*/