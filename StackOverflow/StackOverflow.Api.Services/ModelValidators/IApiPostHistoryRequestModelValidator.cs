using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2541df6d99e767ecf0dff06e2ecb75cd</Hash>
</Codenesium>*/