using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductSubcategoryRequestModelValidator: AbstractValidator<ApiProductSubcategoryRequestModel>
	{
		public new ValidationResult Validate(ApiProductSubcategoryRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductSubcategoryRequestModel model)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryRequestModel.Name));
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

		private async Task<bool> BeUniqueGetName(ApiProductSubcategoryRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ProductSubcategoryRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>9c88320c01157bb1da1605df734275db</Hash>
</Codenesium>*/