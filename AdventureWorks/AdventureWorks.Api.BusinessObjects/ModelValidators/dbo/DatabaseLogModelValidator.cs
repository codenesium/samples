using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDatabaseLogModelValidator: AbstractApiDatabaseLogModelValidator, IApiDatabaseLogModelValidator
	{
		public ApiDatabaseLogModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogModel model)
		{
			this.DatabaseUserRules();
			this.@EventRules();
			this.@ObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TSQLRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogModel model)
		{
			this.DatabaseUserRules();
			this.@EventRules();
			this.@ObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TSQLRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9fb037293ac5b595239ee3f7ab038d63</Hash>
</Codenesium>*/