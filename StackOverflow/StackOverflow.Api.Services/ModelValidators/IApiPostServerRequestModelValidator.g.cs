using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ecc274bb0ee2d72f6390a367650c601a</Hash>
</Codenesium>*/