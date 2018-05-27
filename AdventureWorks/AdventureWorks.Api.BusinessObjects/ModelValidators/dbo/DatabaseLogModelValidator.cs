using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDatabaseLogRequestModelValidator: AbstractApiDatabaseLogRequestModelValidator, IApiDatabaseLogRequestModelValidator
	{
		public ApiDatabaseLogRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model)
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
    <Hash>6b862f2ae0f89b17a79e89b8e5247db5</Hash>
</Codenesium>*/