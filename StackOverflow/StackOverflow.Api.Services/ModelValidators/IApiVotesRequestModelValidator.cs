using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVotesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVotesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f502384c952a083077aa3366570a50d0</Hash>
</Codenesium>*/