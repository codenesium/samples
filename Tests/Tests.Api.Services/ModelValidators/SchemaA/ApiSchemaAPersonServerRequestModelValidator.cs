using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiSchemaAPersonServerRequestModelValidator : AbstractApiSchemaAPersonServerRequestModelValidator, IApiSchemaAPersonServerRequestModelValidator
	{
		public ApiSchemaAPersonServerRequestModelValidator(ISchemaAPersonRepository schemaAPersonRepository)
			: base(schemaAPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>14f26f42a65294a3a6a79069531fe8c6</Hash>
</Codenesium>*/