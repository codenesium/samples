using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiDatabaseLogRequestModelValidator : AbstractApiDatabaseLogRequestModelValidator, IApiDatabaseLogRequestModelValidator
	{
		public ApiDatabaseLogRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
			: base(databaseLogRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model)
		{
			this.DatabaseUserRules();
			this.@EventRules();
			this.@ObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TsqlRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model)
		{
			this.DatabaseUserRules();
			this.@EventRules();
			this.@ObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TsqlRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c80cb62654307b88eac119889500ccc0</Hash>
</Codenesium>*/