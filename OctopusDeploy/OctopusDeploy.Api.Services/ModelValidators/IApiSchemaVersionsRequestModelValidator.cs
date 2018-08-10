using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiSchemaVersionsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaVersionsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaVersionsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cff35099bad604bc027bffaaa765a033</Hash>
</Codenesium>*/