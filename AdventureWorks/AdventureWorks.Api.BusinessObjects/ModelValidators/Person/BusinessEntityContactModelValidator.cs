using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BusinessEntityContactModelValidator: AbstractBusinessEntityContactModelValidator, IBusinessEntityContactModelValidator
	{
		public BusinessEntityContactModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BusinessEntityContactModel model)
		{
			this.PersonIDRules();
			this.ContactTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityContactModel model)
		{
			this.PersonIDRules();
			this.ContactTypeIDRules();
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
    <Hash>834634780d503abb4085df8a97e8b741</Hash>
</Codenesium>*/