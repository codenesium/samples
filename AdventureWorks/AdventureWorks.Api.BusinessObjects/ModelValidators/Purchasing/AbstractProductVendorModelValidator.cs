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
		public IProductRepository ProductRepository { get; set; }
		public IUnitMeasureRepository UnitMeasureRepository { get; set; }
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
			this.RuleFor(x => x.UnitMeasureCode).Must(this.BeValidUnitMeasure).When(x => x ?.UnitMeasureCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}

		private bool BeValidVendor(int id)
		{
			return this.VendorRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidUnitMeasure(string id)
		{
			return this.UnitMeasureRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>0bfa4e01b8e7ad35f7fa13ddff58c356</Hash>
</Codenesium>*/