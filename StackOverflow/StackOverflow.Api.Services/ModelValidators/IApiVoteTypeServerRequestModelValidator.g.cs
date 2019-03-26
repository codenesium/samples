using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f45395874039c0f376e6ee42645f972a</Hash>
</Codenesium>*/