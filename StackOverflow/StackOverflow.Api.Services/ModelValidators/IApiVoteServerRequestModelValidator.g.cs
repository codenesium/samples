using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0ef80bbeb089ff9e15aa1e0d495b4651</Hash>
</Codenesium>*/