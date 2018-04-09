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

		public IProductRepository ProductRepository {get; set;}
		public IVendorRepository VendorRepository {get; set;}
		public IUnitMeasureRepository UnitMeasureRepository {get; set;}
		public virtual void BusinessEntityIDRules()
		{
			RuleFor(x => x.BusinessEntityID).NotNull();
			RuleFor(x => x.BusinessEntityID).Must(BeValidVendor).When(x => x ?.BusinessEntityID != null).WithMessage("Invalid reference");
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
			RuleFor(x => x.UnitMeasureCode).Must(BeValidUnitMeasure).When(x => x ?.UnitMeasureCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.UnitMeasureCode).Length(0,3);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidVendor(int id)
		{
			return this.VendorRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidUnitMeasure(string id)
		{
			return this.UnitMeasureRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>58d76f2fbafa8eb69d0c6a477752af89</Hash>
</Codenesium>*/