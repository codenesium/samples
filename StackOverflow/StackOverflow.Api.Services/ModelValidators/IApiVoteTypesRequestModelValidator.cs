using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>906959c24e77a72f3e8b44e444c2f18f</Hash>
</Codenesium>*/