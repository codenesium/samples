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
			this.DatabaseUserRules();
			this.@EventRules();
			this.@ObjectRules();
			this.PostTimeRules();
			this.SchemaRules();
			this.TSQLRules();
			this.XmlEventRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, DatabaseLogModel model)
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
    <Hash>859da26e1e6d9eefba3f3e1c4efb9fc8</Hash>
</Codenesium>*/