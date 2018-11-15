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

		private ISalesTaxRateRepository salesTaxRateRepository;

		public AbstractApiSalesTaxRateServerRequestModelValidator(ISalesTaxRateRepository salesTaxRateRepository)
		{
			this.salesTaxRateRepository = salesTaxRateRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateServerRequestModel.Rowguid));
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => !x?.StateProvinceID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateServerRequestModel.StateProvinceID));
		}

		public virtual void TaxRateRules()
		{
		}

		public virtual void TaxTypeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => !x?.TaxType.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateServerRequestModel.TaxType));
		}

		private async Task<bool> BeUniqueByRowguid(ApiSalesTaxRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTaxRate record = await this.salesTaxRateRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.SalesTaxRateID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByStateProvinceIDTaxType(ApiSalesTaxRateServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTaxRate record = await this.salesTaxRateRepository.ByStateProvinceIDTaxType(model.StateProvinceID, model.TaxType);

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
    <Hash>e220c9f100c62315f12c5f07cf82d774</Hash>
</Codenesium>*/