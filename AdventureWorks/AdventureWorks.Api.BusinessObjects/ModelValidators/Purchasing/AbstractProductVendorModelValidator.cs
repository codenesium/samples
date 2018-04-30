using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IVendorRepository VendorRepository { get; set; }
		public virtual void AverageLeadTimeRules()
		{
			this.RuleFor(x => x.AverageLeadTime).NotNull();
		}

		public virtual void BusinessEntityIDRules()
		{
			this.RuleFor(x => x.BusinessEntityID).NotNull();
			this.RuleFor(x => x.BusinessEntityID).Must(this.BeValidVendor).When(x => x ?.BusinessEntityID != null).WithMessage("Invalid reference");
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

		private bool BeValidVendor(int id)
		{
			return this.VendorRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>82fa2d9fd9b4727cb36efd95d7ee578c</Hash>
</Codenesium>*/