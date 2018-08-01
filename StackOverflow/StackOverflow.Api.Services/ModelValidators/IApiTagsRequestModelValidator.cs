using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiTagsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>436fd8c6f6009cfc0feb703f7a1f13c4</Hash>
</Codenesium>*/