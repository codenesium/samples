using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagsServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagsServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a118df4e16475d46e596f4479b64a040</Hash>
</Codenesium>*/