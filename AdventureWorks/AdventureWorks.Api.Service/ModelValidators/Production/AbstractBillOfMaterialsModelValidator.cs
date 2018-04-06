using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractBillOfMaterialsModelValidator: AbstractValidator<BillOfMaterialsModel>
	{
		public new ValidationResult Validate(BillOfMaterialsModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BillOfMaterialsModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository {get; set;}
		public IUnitMeasureRepository UnitMeasureRepository {get; set;}
		public virtual void ProductAssemblyIDRules()
		{
			RuleFor(x => x.ProductAssemblyID).Must(BeValidProduct).When(x => x ?.ProductAssemblyID != null).WithMessage("Invalid reference");
		}

		public virtual void ComponentIDRules()
		{
			RuleFor(x => x.ComponentID).NotNull();
			RuleFor(x => x.ComponentID).Must(BeValidProduct).When(x => x ?.ComponentID != null).WithMessage("Invalid reference");
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void UnitMeasureCodeRules()
		{
			RuleFor(x => x.UnitMeasureCode).NotNull();
			RuleFor(x => x.UnitMeasureCode).Must(BeValidUnitMeasure).When(x => x ?.UnitMeasureCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.UnitMeasureCode).Length(0,3);
		}

		public virtual void BOMLevelRules()
		{
			RuleFor(x => x.BOMLevel).NotNull();
		}

		public virtual void PerAssemblyQtyRules()
		{
			RuleFor(x => x.PerAssemblyQty).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidProduct(Nullable<int> id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id.GetValueOrDefault(),response);
			return response.Products.Count > 0;
		}

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
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
    <Hash>7e8e2795b76f0596a7a173e357746c55</Hash>
</Codenesium>*/