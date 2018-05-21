using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductSubcategoryModelValidator: AbstractValidator<ApiProductSubcategoryModel>
	{
		public new ValidationResult Validate(ApiProductSubcategoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductSubcategoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductSubcategoryRepository ProductSubcategoryRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductCategoryIDRules()
		{
			this.RuleFor(x => x.ProductCategoryID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeUniqueGetName(ApiProductSubcategoryModel model)
		{
			return this.ProductSubcategoryRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>f30200fb21bc26fddb6f50a4069f6d39</Hash>
</Codenesium>*/