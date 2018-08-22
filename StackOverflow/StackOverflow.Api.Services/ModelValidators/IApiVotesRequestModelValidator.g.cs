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
    <Hash>e5c1ece62321307bbe6bfd7782c63f15</Hash>
</Codenesium>*/