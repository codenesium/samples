using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiSchemaVersionsRequestModelValidator : AbstractApiSchemaVersionsRequestModelValidator, IApiSchemaVersionsRequestModelValidator
	{
		public ApiSchemaVersionsRequestModelValidator(ISchemaVersionsRepository schemaVersionsRepository)
			: base(schemaVersionsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaVersionsRequestModel model)
		{
			this.AppliedRules();
			this.ScriptNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaVersionsRequestModel model)
		{
			this.AppliedRules();
			this.ScriptNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>80cdbe61df5918525f3229ff18e478e5</Hash>
</Codenesium>*/