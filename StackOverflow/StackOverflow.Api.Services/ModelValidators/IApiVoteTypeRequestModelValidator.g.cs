using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0c950589ed72b9a6c53db02ce7f85f49</Hash>
</Codenesium>*/