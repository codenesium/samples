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
    <Hash>e682277bb3db2b684e45cd663734db24</Hash>
</Codenesium>*/