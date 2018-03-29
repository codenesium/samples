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

		public IProductRepository ProductRepository {get; set;}
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
			RuleFor(x => x.ProductID).Must(BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
			RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>cb95378aee21a871af1869a445ace873</Hash>
</Codenesium>*/