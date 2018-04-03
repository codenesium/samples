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

		public virtual void ProductCategoryIDRules()
		{
			RuleFor(x => x.ProductCategoryID).NotNull();
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
	}
}

/*<Codenesium>
    <Hash>0e19884f20dca45a9e2881131aa0d4d0</Hash>
</Codenesium>*/