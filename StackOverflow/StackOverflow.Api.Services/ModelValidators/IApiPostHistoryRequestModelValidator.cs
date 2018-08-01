using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiPostHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>73961725eab59b70d630437299b0e5f0</Hash>
</Codenesium>*/