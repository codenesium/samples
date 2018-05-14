using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiShoppingCartItemModelValidator: AbstractApiShoppingCartItemModelValidator, IApiShoppingCartItemModelValidator
	{
		public ApiShoppingCartItemModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemModel model)
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
    <Hash>ad3ec43ac578923ed00fd0452d534d37</Hash>
</Codenesium>*/