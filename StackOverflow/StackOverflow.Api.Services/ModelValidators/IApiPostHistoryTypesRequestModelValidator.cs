using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiPostHistoryTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>55eac1ab26009d05d9a1c2bfd4073e17</Hash>
</Codenesium>*/