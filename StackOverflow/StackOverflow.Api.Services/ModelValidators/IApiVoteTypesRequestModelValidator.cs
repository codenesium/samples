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
    <Hash>37279656235f3873380c3cacbf856bf4</Hash>
</Codenesium>*/