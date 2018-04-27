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
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShoppingCartItemModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c26b04f7d7f3185af6c34f6bae72e50e</Hash>
</Codenesium>*/