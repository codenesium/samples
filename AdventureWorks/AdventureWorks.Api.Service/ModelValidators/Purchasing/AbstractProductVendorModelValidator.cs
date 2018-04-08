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

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
		}

		public bool BeValidVendor(int id)
		{
			Response response = new Response();

			this.VendorRepository.GetById(id,response);
			return response.Vendors.Count > 0;
		}

		public bool BeValidUnitMeasure(string id)
		{
			Response response = new Response();

			this.UnitMeasureRepository.GetById(id,response);
			return response.UnitMeasures.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>1d21b7ecd72d82bc4dd47adb2ebadadd</Hash>
</Codenesium>*/