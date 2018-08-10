using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypesNullableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypesNullableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypesNullableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>305414774cb719f9883cb76acb1330b7</Hash>
</Codenesium>*/