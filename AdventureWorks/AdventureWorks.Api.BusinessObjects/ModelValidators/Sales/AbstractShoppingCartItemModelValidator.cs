using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShoppingCartItemModelValidator: AbstractValidator<ApiShoppingCartItemModel>
	{
		public new ValidationResult Validate(ApiShoppingCartItemModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShoppingCartItemModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DateCreatedRules()
		{
			this.RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ShoppingCartIDRules()
		{
			this.RuleFor(x => x.ShoppingCartID).NotNull();
			this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>88ed842d08d57cb68a33fad79cacca51</Hash>
</Codenesium>*/