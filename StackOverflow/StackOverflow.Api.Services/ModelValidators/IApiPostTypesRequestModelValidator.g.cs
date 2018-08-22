using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e334127f070b166d208d7cc3c0b0d929</Hash>
</Codenesium>*/