using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShoppingCartItemRequestModelValidator: AbstractApiShoppingCartItemRequestModelValidator, IApiShoppingCartItemRequestModelValidator
	{
		public ApiShoppingCartItemRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b63a0e91393e070297eb49757ce0a01c</Hash>
</Codenesium>*/