using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ca76de6f8b05d41e9a8d7cc0dde2cbaa</Hash>
</Codenesium>*/