using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98e29bc3b250aeae8102487501e3ff7d</Hash>
</Codenesium>*/