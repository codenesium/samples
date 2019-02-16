using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiDatabaseLogServerRequestModelValidator : AbstractApiDatabaseLogServerRequestModelValidator, IApiDatabaseLogServerRequestModelValidator
	{
		public ApiDatabaseLogServerRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
			: base(databaseLogRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogServerRequestModel model)
		{
			this.DatabaseUserRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TsqlRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogServerRequestModel model)
		{
			this.DatabaseUserRules();
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
    <Hash>13fd528a759f44f697873ad044020cd2</Hash>
</Codenesium>*/