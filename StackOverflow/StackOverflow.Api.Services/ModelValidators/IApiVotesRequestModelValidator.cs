using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiVotesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVotesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f95c7d1e7ae0cbd04141921dd398a302</Hash>
</Codenesium>*/