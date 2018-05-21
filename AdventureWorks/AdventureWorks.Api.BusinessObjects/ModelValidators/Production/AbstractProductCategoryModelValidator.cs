using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductCategoryModelValidator: AbstractValidator<ApiProductCategoryModel>
	{
		public new ValidationResult Validate(ApiProductCategoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCategoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductCategoryRepository ProductCategoryRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeUniqueGetName(ApiProductCategoryModel model)
		{
			return this.ProductCategoryRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>48e0f253c92395381d6473ad0a5c93f2</Hash>
</Codenesium>*/