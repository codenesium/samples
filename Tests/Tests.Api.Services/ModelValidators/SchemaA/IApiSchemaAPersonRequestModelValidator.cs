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
    <Hash>818d52cf07793785e5216f9b76c08559</Hash>
</Codenesium>*/