using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d838eba947441f357bce329efbda46c0</Hash>
</Codenesium>*/