using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryTypesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bbbcbaf5d5e62b8fbfe81bc5fa6dfa01</Hash>
</Codenesium>*/