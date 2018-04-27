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
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityContactModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
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
    <Hash>553e48d0e67580dfa9026e0571919c78</Hash>
</Codenesium>*/