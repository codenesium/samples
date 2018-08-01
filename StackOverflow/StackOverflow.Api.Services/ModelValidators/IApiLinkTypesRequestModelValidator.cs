using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiLinkTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>758d449c1fd4a3f010968eacad301a54</Hash>
</Codenesium>*/