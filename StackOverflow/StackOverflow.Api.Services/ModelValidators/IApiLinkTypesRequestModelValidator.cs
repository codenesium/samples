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
    <Hash>faa8f886ec1bbd1ba9ea66bb7c40bf54</Hash>
</Codenesium>*/