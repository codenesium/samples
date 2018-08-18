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
    <Hash>6dc24bbad7d4759c3bb080f14702ab6a</Hash>
</Codenesium>*/