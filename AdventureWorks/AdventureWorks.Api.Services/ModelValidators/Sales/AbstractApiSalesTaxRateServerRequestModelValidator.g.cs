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
	public abstract class AbstractApiSalesTaxRateServerRequestModelValidator : AbstractValidator<ApiSalesTaxRateServerRequestModel>
	{
		private int existingRecordId;

		protected ISalesTaxRateRepository SalesTaxRateRepository { get; private set; }

		public AbstractApiSalesTaxRateServerRequestModelValidator(ISalesTaxRateRepository salesTaxRateRepository)
		{
			this.SalesTaxRateRepository = salesTaxRateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTaxRateServerRequestModel model, int id)
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
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => (!x?.StateProvinceID.IsEmptyOrZeroOrNull() ?? false) || (!x?.TaxType.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateServerRequestModel.StateProvinceID)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void TaxRateRules()
		{
		}

		public virtual void TaxTypeRules()
		{
		}

		protected async Task<bool> BeUniqueByRowguid(ApiSalesTaxRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTaxRate record = await this.SalesTaxRateRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.SalesTaxRateID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByStateProvinceIDTaxType(ApiSalesTaxRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTaxRate record = await this.SalesTaxRateRepository.ByStateProvinceIDTaxType(model.StateProvinceID, model.TaxType);

			if (record == null || (this.existingRecordId != default(int) && record.SalesTaxRateID == this.existingRecordId))
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
    <Hash>e08b3d944ad222dbe88e0ee5d826865f</Hash>
</Codenesium>*/