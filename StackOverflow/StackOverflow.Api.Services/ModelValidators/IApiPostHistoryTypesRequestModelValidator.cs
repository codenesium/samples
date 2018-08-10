using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>27994c7e30dccf5e97ff27e5fc43a447</Hash>
</Codenesium>*/