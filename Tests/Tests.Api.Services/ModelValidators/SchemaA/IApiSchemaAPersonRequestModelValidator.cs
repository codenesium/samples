using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaAPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98cbe1928504fe1d511559cbed7f7d9e</Hash>
</Codenesium>*/