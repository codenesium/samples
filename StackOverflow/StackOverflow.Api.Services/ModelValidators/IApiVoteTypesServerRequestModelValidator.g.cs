using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>23d5393b9159a358dda19a4a1940930b</Hash>
</Codenesium>*/