using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVotesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVotesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4c20531eddb463a4503676d54c231d10</Hash>
</Codenesium>*/