using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaAPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cc9ef4357be1aa46e16076cc7b214751</Hash>
</Codenesium>*/