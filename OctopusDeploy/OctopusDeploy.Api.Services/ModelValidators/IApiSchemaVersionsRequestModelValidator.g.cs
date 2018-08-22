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
    <Hash>e75e5348005e101e9506010d044eef8b</Hash>
</Codenesium>*/