using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiReplyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiReplyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiReplyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>128dc237775ac435aeed16643de18ca6</Hash>
</Codenesium>*/