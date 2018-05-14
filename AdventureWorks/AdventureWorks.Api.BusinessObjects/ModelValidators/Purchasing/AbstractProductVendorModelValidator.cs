using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductVendorModelValidator: AbstractValidator<ApiProductVendorModel>
	{
		public new ValidationResult Validate(ApiProductVendorModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductVendorModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AverageLeadTimeRules()
		{
			this.RuleFor(x => x.AverageLeadTime).NotNull();
		}

		public virtual void BusinessEntityIDRules()
		{
			this.RuleFor(x => x.BusinessEntityID).NotNull();
		}

		public virtual void LastReceiptCostRules()
		{                       }

		public virtual void LastReceiptDateRules()
		{                       }

		public virtual void MaxOrderQtyRules()
		{
			this.RuleFor(x => x.MaxOrderQty).NotNull();
		}

		public virtual void MinOrderQtyRules()
		{
			this.RuleFor(x => x.MinOrderQty).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OnOrderQtyRules()
		{                       }

		public virtual void StandardPriceRules()
		{
			this.RuleFor(x => x.StandardPrice).NotNull();
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}
	}
}

/*<Codenesium>
    <Hash>b53fe2221cefa57d2517307a59c40479</Hash>
</Codenesium>*/