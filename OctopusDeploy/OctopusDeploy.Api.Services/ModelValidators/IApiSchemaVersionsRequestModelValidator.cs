using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiSchemaVersionsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaVersionsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaVersionsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>afe2d7b3e6c459e5da6a180bd4a8afa2</Hash>
</Codenesium>*/