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
			this.ReservedEventRules();
			this.ReservedObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TsqlRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogServerRequestModel model)
		{
			this.DatabaseUserRules();
			this.ReservedEventRules();
			this.ReservedObjectRules();
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
    <Hash>37a2a212f8e6f7018f277710d065503c</Hash>
</Codenesium>*/