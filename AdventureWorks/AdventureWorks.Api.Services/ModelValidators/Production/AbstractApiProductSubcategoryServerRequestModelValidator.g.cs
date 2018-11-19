using AdventureWorksNS.Api.Contracts;
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
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProductCategoryIDRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
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
    <Hash>36f5e76522fb65a9b45a16509f7107ce</Hash>
</Codenesium>*/