using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractShoppingCartItemModelValidator: AbstractValidator<ShoppingCartItemModel>
	{
		public new ValidationResult Validate(ShoppingCartItemModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ShoppingCartItemModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ShoppingCartIDRules()
		{
			RuleFor(x => x.ShoppingCartID).NotNull();
			RuleFor(x => x.ShoppingCartID).Length(0,50);
		}

		public virtual void QuantityRules()
		{
			RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void DateCreatedRules()
		{
			RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>c8214a5b2ef5c5393104b118f9425195</Hash>
</Codenesium>*/