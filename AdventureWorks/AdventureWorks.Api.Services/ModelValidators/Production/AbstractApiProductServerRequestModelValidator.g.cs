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
	public abstract class AbstractApiProductServerRequestModelValidator : AbstractValidator<ApiProductServerRequestModel>
	{
		private int existingRecordId;

		protected IProductRepository ProductRepository { get; private set; }

		public AbstractApiProductServerRequestModelValidator(IProductRepository productRepository)
		{
			this.ProductRepository = productRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ReservedClassRules()
		{
			this.RuleFor(x => x.ReservedClass).Length(0, 2).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ColorRules()
		{
			this.RuleFor(x => x.Color).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DaysToManufactureRules()
		{
		}

		public virtual void DiscontinuedDateRules()
		{
		}

		public virtual void FinishedGoodsFlagRules()
		{
		}

		public virtual void ListPriceRules()
		{
		}

		public virtual void MakeFlagRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProductLineRules()
		{
			this.RuleFor(x => x.ProductLine).Length(0, 2).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProductModelIDRules()
		{
			this.RuleFor(x => x.ProductModelID).MustAsync(this.BeValidProductModelByProductModelID).When(x => !x?.ProductModelID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ProductNumberRules()
		{
			this.RuleFor(x => x.ProductNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProductNumber).When(x => (!x?.ProductNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductServerRequestModel.ProductNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.ProductNumber).Length(0, 25).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProductSubcategoryIDRules()
		{
			this.RuleFor(x => x.ProductSubcategoryID).MustAsync(this.BeValidProductSubcategoryByProductSubcategoryID).When(x => !x?.ProductSubcategoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ReorderPointRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SafetyStockLevelRules()
		{
		}

		public virtual void SellEndDateRules()
		{
		}

		public virtual void SellStartDateRules()
		{
		}

		public virtual void SizeRules()
		{
			this.RuleFor(x => x.Size).Length(0, 5).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SizeUnitMeasureCodeRules()
		{
			this.RuleFor(x => x.SizeUnitMeasureCode).MustAsync(this.BeValidUnitMeasureBySizeUnitMeasureCode).When(x => !x?.SizeUnitMeasureCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
			this.RuleFor(x => x.SizeUnitMeasureCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StandardCostRules()
		{
		}

		public virtual void StyleRules()
		{
			this.RuleFor(x => x.Style).Length(0, 2).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WeightRules()
		{
		}

		public virtual void WeightUnitMeasureCodeRules()
		{
			this.RuleFor(x => x.WeightUnitMeasureCode).MustAsync(this.BeValidUnitMeasureByWeightUnitMeasureCode).When(x => !x?.WeightUnitMeasureCode.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
			this.RuleFor(x => x.WeightUnitMeasureCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidProductModelByProductModelID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductRepository.ProductModelByProductModelID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidProductSubcategoryByProductSubcategoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductRepository.ProductSubcategoryByProductSubcategoryID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUnitMeasureBySizeUnitMeasureCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductRepository.UnitMeasureBySizeUnitMeasureCode(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUnitMeasureByWeightUnitMeasureCode(string id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductRepository.UnitMeasureByWeightUnitMeasureCode(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeUniqueByName(ApiProductServerRequestModel model,  CancellationToken cancellationToken)
		{
			Product record = await this.ProductRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByProductNumber(ApiProductServerRequestModel model,  CancellationToken cancellationToken)
		{
			Product record = await this.ProductRepository.ByProductNumber(model.ProductNumber);

			if (record == null || (this.existingRecordId != default(int) && record.ProductID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiProductServerRequestModel model,  CancellationToken cancellationToken)
		{
			Product record = await this.ProductRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductID == this.existingRecordId))
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
    <Hash>27e01442602c6dbcfbbe19e686637a1d</Hash>
</Codenesium>*/