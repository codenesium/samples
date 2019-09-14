using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>aa5a2604fe0f8de8e02b301512e8dd3f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/