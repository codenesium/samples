using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBusinessEntityModelValidator: AbstractApiBusinessEntityModelValidator, IApiBusinessEntityModelValidator
	{
		public ApiBusinessEntityModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityModel model)
		{
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityModel model)
		{
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>63a4c8ccc4c0e649c1758d9e95673c0d</Hash>
</Codenesium>*/