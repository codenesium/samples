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
    <Hash>046fc48a26e6ebc0b50b318eb342a0ee</Hash>
</Codenesium>*/