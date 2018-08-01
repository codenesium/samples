using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiSchemaAPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c218784ef42a956ab70d6a8ab2f83d7</Hash>
</Codenesium>*/