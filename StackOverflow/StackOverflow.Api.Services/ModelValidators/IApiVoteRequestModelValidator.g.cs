using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4e0beb93fb2a38bd4933b7bac654921</Hash>
</Codenesium>*/