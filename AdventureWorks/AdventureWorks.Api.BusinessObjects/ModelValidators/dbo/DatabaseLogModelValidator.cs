using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class DatabaseLogModelValidator: AbstractDatabaseLogModelValidator, IDatabaseLogModelValidator
	{
		public DatabaseLogModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(DatabaseLogModel model)
		{
			this.PostTimeRules();
			this.DatabaseUserRules();
			this.@EventRules();
			this.SchemaRules();
			this.@ObjectRules();
			this.TSQLRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, DatabaseLogModel model)
		{
			this.PostTimeRules();
			this.DatabaseUserRules();
			this.@EventRules();
			this.SchemaRules();
			this.@ObjectRules();
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
    <Hash>65567617d2d79832f10746ddc89c585f</Hash>
</Codenesium>*/