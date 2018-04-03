using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductVendorModelValidator: AbstractValidator<ProductVendorModel>
	{
		public new ValidationResult Validate(ProductVendorModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductVendorModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void BusinessEntityIDRules()
		{
			RuleFor(x => x.BusinessEntityID).NotNull();
		}

		public virtual void AverageLeadTimeRules()
		{
			RuleFor(x => x.AverageLeadTime).NotNull();
		}

		public virtual void StandardPriceRules()
		{
			RuleFor(x => x.StandardPrice).NotNull();
		}

		public virtual void LastReceiptCostRules()
		{                       }

		public virtual void LastReceiptDateRules()
		{                       }

		public virtual void MinOrderQtyRules()
		{
			RuleFor(x => x.MinOrderQty).NotNull();
		}

		public virtual void MaxOrderQtyRules()
		{
			RuleFor(x => x.MaxOrderQty).NotNull();
		}

		public virtual void OnOrderQtyRules()
		{                       }

		public virtual void UnitMeasureCodeRules()
		{
			RuleFor(x => x.UnitMeasureCode).NotNull();
			RuleFor(x => x.UnitMeasureCode).Length(0,3);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>36427f4820d80add340411197d3cb9a5</Hash>
</Codenesium>*/