using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductSubcategoryServerRequestModelValidator : AbstractValidator<ApiProductSubcategoryServerRequestModel>
	{
		private int existingRecordId;

		private IProductSubcategoryRepository productSubcategoryRepository;

		public AbstractApiProductSubcategoryServerRequestModelValidator(IProductSubcategoryRepository productSubcategoryRepository)
		{
			this.productSubcategoryRepository = productSubcategoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductSubcategoryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductCategoryIDRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByName(ApiProductSubcategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductSubcategory record = await this.productSubcategoryRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductSubcategoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiProductSubcategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductSubcategory record = await this.productSubcategoryRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductSubcategoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>83d618b1c894f05474df7f7e7a3cd6b9</Hash>
</Codenesium>*/