using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1f1671a511c828a3f07d020980ddbb9a</Hash>
</Codenesium>*/