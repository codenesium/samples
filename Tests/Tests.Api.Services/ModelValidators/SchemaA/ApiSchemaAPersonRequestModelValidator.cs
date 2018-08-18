using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiSchemaAPersonRequestModelValidator : AbstractApiSchemaAPersonRequestModelValidator, IApiSchemaAPersonRequestModelValidator
	{
		public ApiSchemaAPersonRequestModelValidator(ISchemaAPersonRepository schemaAPersonRepository)
			: base(schemaAPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaAPersonRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaAPersonRequestModel model)
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
    <Hash>ff5e6aeb3aec6b9fb3060d79c070b1d8</Hash>
</Codenesium>*/