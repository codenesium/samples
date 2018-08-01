using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiVoteTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>05451e05f676d3c3f4126eb394ac0e1b</Hash>
</Codenesium>*/