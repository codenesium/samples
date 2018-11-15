using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypesNullableServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypesNullableServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypesNullableServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e8eef36a704f5e914ffcc9f7ec7974bc</Hash>
</Codenesium>*/