using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ShoppingCartItemModelValidator: AbstractShoppingCartItemModelValidator, IShoppingCartItemModelValidator
	{
		public ShoppingCartItemModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ShoppingCartItemModel model)
		{
			this.ShoppingCartIDRules();
			this.QuantityRules();
			this.ProductIDRules();
			this.DateCreatedRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShoppingCartItemModel model)
		{
			this.ShoppingCartIDRules();
			this.QuantityRules();
			this.ProductIDRules();
			this.DateCreatedRules();
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
    <Hash>7a061a34a1f5768653982f6c3170013d</Hash>
</Codenesium>*/