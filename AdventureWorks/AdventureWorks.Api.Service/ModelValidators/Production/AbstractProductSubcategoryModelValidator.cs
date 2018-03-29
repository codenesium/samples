using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductSubcategoryModelValidator: AbstractValidator<ProductSubcategoryModel>
	{
		public new ValidationResult Validate(ProductSubcategoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductSubcategoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductCategoryRepository ProductCategoryRepository {get; set;}
		public virtual void ProductCategoryIDRules()
		{
			RuleFor(x => x.ProductCategoryID).NotNull();
			RuleFor(x => x.ProductCategoryID).Must(BeValidProductCategory).When(x => x ?.ProductCategoryID != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidProductCategory(int id)
		{
			Response response = new Response();

			this.ProductCategoryRepository.GetById(id,response);
			return response.ProductCategories.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>6018dcbbcb055b276c08aa5566c9c849</Hash>
</Codenesium>*/