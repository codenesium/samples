using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BusinessEntityModelValidator: AbstractBusinessEntityModelValidator, IBusinessEntityModelValidator
	{
		public BusinessEntityModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BusinessEntityModel model)
		{
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityModel model)
		{
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c4387cc592446dc4fdf73d9703036894</Hash>
</Codenesium>*/